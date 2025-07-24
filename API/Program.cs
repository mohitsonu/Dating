using API.Data;
using API.Entities;
using API.Extensions;
using API.Middleware;
using API.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var connString = "";
if (builder.Environment.IsDevelopment())
    connString = builder.Configuration.GetConnectionString("DefaultConnection");
// else
// {
//     // Use connection string provided at runtime by FlyIO.
//     var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

//     // Parse connection URL to connection string for Npgsql
//     connUrl = connUrl.Replace("postgres://", string.Empty);
//     var pgUserPass = connUrl.Split("@")[0];
//     var pgHostPortDb = connUrl.Split("@")[1];
//     var pgHostPort = pgHostPortDb.Split("/")[0];
//     var pgDb = pgHostPortDb.Split("/")[1];
//     var pgUser = pgUserPass.Split(":")[0];
//     var pgPass = pgUserPass.Split(":")[1];
//     var pgHost = pgHostPort.Split(":")[0];
//     var pgPort = pgHostPort.Split(":")[1];

//     connString = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};";
// }
else
{
    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (string.IsNullOrEmpty(connUrl))
    {
        throw new InvalidOperationException("DATABASE_URL environment variable is missing!");
    }

    try
    {
        // Remove protocol
        connUrl = connUrl.Replace("postgres://", string.Empty);

        var atSplit = connUrl.Split("@");
        if (atSplit.Length != 2)
            throw new FormatException("DATABASE_URL format is invalid (missing '@').");

        var pgUserPass = atSplit[0];
        var pgHostPortDb = atSplit[1];

        var userPassSplit = pgUserPass.Split(":");
        if (userPassSplit.Length != 2)
            throw new FormatException("DATABASE_URL user/pass format is invalid.");

        var pgUser = userPassSplit[0];
        var pgPass = userPassSplit[1];

        var hostPortDbSplit = pgHostPortDb.Split("/");
        if (hostPortDbSplit.Length < 2)
            throw new FormatException("DATABASE_URL host/port/db format is invalid.");

        var pgHostPort = hostPortDbSplit[0];
        var pgDb = hostPortDbSplit[1];

        var hostPortSplit = pgHostPort.Split(":");
        if (hostPortSplit.Length != 2)
            throw new FormatException("DATABASE_URL host/port format is invalid.");

        var pgHost = hostPortSplit[0];
        var pgPort = hostPortSplit[1];

        // Compose final connection string
        connString = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};Ssl Mode=Require;Trust Server Certificate=true;";

    }
    catch (Exception ex)
    {
        throw new InvalidOperationException($"Failed to parse DATABASE_URL: {ex.Message}");
    }
}
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapHub<PresenceHub>("hubs/presence");
app.MapHub<MessageHub>("hubs/message");
app.MapFallbackToController("Index", "Fallback");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.ClearConnections(context);
    await Seed.SeedUsers(userManager, roleManager);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
