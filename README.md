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
-   [Screenshots](#-screenshots)
-   [Technology Stack](#technology-stack)
-   [Getting Started](#getting-started)
    -   [Prerequisites](#prerequisites)
    -   [Frontend (Client) Setup](#frontend-client-setup)
-   [Usage](#usage)
-   [Project Structure](#project-structure)
-   [Deployment](#-deployment)
-   [Contributing](#contributing)
-   [License](#license)


*(You can add or remove features here as you build them out!)*

## Technology Stack

### Backend
    cd API
    ```

2.  **Configure Settings:**
    - In the `API` directory, find the `appsettings.Development.json` file.
    - Ensure the `ConnectionStrings.DefaultConnection` is set up for your local database (e.g., SQLite or SQL Server).
    - Ensure you have a secret `TokenKey` for JWT generation. **Do not commit this key to a public repository.**

2.  **Restore .NET dependencies:**
    ```sh
    dotnet restore

You can now register a new account, log in, and begin using the application.

## 🚀 Deployment

This application is deployed on [Render](https://render.com/).

- The **API** is deployed as a **Web Service** running the .NET environment. On Render, this involves pointing to the `API.csproj` file and letting the buildpack handle the rest.
- The **Client** is deployed as a **Static Site**. The build command is `npm install && ng build` and the publish directory is `client/dist/client`.

Environment variables for the production database connection string and JWT token key are configured securely in the Render dashboard.

Continuous deployment is set up to automatically build and deploy the latest changes pushed to the `main` branch.

## Project Structure

The repository contains two main projects:

