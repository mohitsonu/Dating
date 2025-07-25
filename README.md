# Dating App

<div align="center">

[![.NET](https://img.shields.io/badge/.NET-7-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
[![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)](https://angular.io/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=for-the-badge)](/LICENSE)

</div>

A full-stack dating application built with an ASP.NET Core backend and an Angular frontend. This project serves as a modern example of building and connecting a web API with a single-page application (SPA).

## ✨ Live Demo

You can try the live application here: **[https://dating-lb7n.onrender.com/](https://dating-lb7n.onrender.com/)**

## Table of Contents

-   [Features](#features)
-   [Technology Stack](#technology-stack)
-   [Getting Started](#getting-started)
    -   [Prerequisites](#prerequisites)
    -   [Backend (API) Setup](#backend-api-setup)
    -   [Frontend (Client) Setup](#frontend-client-setup)
-   [Usage](#usage)
-   [Project Structure](#project-structure)
-   [Deployment](#-deployment)
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
-   **Database:** PostgreSQL, hosted on [Neon](https://neon.tech/)
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

2.  **Configure Settings:**
    - In the `API` directory, find the `appsettings.Development.json` file.
    - Ensure the `ConnectionStrings.DefaultConnection` is set up for your local database (e.g., SQLite or SQL Server).
    - Ensure you have a secret `TokenKey` for JWT generation. **Do not commit this key to a public repository.**

3.  **Restore .NET dependencies:**
    ```sh
    dotnet restore
    ```

4.  **Run database migrations (if using Entity Framework):**
    ```sh
    dotnet ef database update
    ```
    *Note: You may need to configure your `appsettings.Development.json` with the correct database connection string first.*

5.  **Run the API:**
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

## 🚀 Deployment

This application is deployed on Render.

- The **API** is deployed as a **Web Service** running the .NET environment. On Render, this involves pointing to the `API.csproj` file and letting the buildpack handle the rest.
- The **Client** is deployed as a **Static Site**. The build command is `npm install && ng build` and the publish directory is `client/dist/client`.

Environment variables for the production database connection string and JWT token key are configured securely in the Render dashboard.

Continuous deployment is set up to automatically build and deploy the latest changes pushed to the `main` branch.

## Project Structure

The repository contains two main projects:

-   `API/`: The ASP.NET Core Web API solution and all backend-related source code.
-   `client/`: The Angular client application and all frontend-related source code.

## Contributing

Contributions are welcome! Please feel free to fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the MIT License. You can create a `LICENSE` file in the root of the project for more details.
