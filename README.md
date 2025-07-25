# Dating App

A full-stack dating application built with an ASP.NET Core backend and an Angular frontend. This project serves as a modern example of building and connecting a web API with a single-page application (SPA).

## Table of Contents

-   [Features](#features)
-   [Technology Stack](#technology-stack)
-   [Getting Started](#getting-started)
    -   [Prerequisites](#prerequisites)
    -   [Backend (API) Setup](#backend-api-setup)
    -   [Frontend (Client) Setup](#frontend-client-setup)
-   [Usage](#usage)
-   [Project Structure](#project-structure)
-   [Contributing](#contributing)
-   [License](#license)

## Features

Here are some of the core features of the application.

-   **User Authentication:** Secure user registration and login using JWTs.
-   **User Profiles:** Create, edit, and view user profiles with photos and personal details.
-   **Member Browsing:** Browse through a gallery of other members.
-   **Photo Management:** Upload and manage profile pictures.

*(You can add or remove features here as you build them out!)*

## Technology Stack

### Backend

-   **Framework:** ASP.NET Core 7
-   **Language:** C#
-   **Database:** *(e.g., SQLite, SQL Server - please specify which one you are using)*
-   **Authentication:** JSON Web Tokens (JWT)

### Frontend

-   **Framework:** Angular
-   **Language:** TypeScript
-   **Styling:** Bootstrap & Bootswatch for a responsive, modern UI.
-   **HTTP Client:** Angular's `HttpClient` for communicating with the backend API.
-   **Testing:** Karma & Jasmine for unit tests.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing.

### Prerequisites

Make sure you have the following software installed:

-   .NET 7 SDK
-   Node.js (which includes npm)
-   Angular CLI: `npm install -g @angular/cli`
-   A code editor like Visual Studio Code

### Backend (API) Setup

1.  **Navigate to the API directory:**
    ```sh
    cd API
    ```

2.  **Restore .NET dependencies:**
    ```sh
    dotnet restore
    ```

3.  **Run database migrations (if using Entity Framework):**
    ```sh
    dotnet ef database update
    ```
    *Note: You may need to configure your `appsettings.Development.json` with the correct database connection string first.*

4.  **Run the API:**
    ```sh
    dotnet watch run
    ```
    The API will start and listen on `https://localhost:5001` (or a similar port).

### Frontend (Client) Setup

1.  **In a new terminal, navigate to the client directory:**
    ```sh
    cd client
    ```

2.  **Install npm packages:**
    ```sh
    npm install
    ```

3.  **Run the Angular development server:**
    ```sh
    ng serve
    ```

## Usage

Once both the backend and frontend are running, open your web browser and navigate to `http://localhost:4200`. The Angular app will load, and it is configured to automatically proxy API requests to your backend server.

You can now register a new account, log in, and begin using the application.

## Project Structure

The repository contains two main projects:

-   `API/`: The ASP.NET Core Web API solution and all backend-related source code.
-   `client/`: The Angular client application and all frontend-related source code.

## Contributing

Contributions are welcome! Please feel free to fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the MIT License. You can create a `LICENSE` file in the root of the project for more details.

