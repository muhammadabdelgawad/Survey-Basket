# Survey-Basket

## Description

This project provides an API for managing polls and user authentication. It allows users to create, read, update, and delete polls, as well as manage user authentication using JWT tokens and refresh tokens.

## Features and Functionality

*   **User Authentication:**
    *   Login with email and password to obtain a JWT token and refresh token.
    *   Refresh JWT tokens using refresh tokens.
    *   Revoke refresh tokens.
    *   Secure API endpoints using JWT authentication.

*   **Poll Management:**
    *   Create new polls with a title, summary, start date, and end date.
    *   Retrieve all polls.
    *   Retrieve a specific poll by ID.
    *   Update existing polls.
    *   Delete polls.
    *   Toggle the publish status of a poll.

## Technology Stack

*   .NET 9.0
*   ASP.NET Core API
*   Entity Framework Core (for database interaction)
*   SQL Server (as the database)
*   JWT (JSON Web Tokens) for authentication
*   Mapster (for object mapping)
*   FluentValidation (for request validation)
*   Microsoft Identity (for user management)

## Prerequisites

*   .NET 9.0 SDK installed.
*   SQL Server instance.
*   An IDE like Visual Studio or Visual Studio Code.

## Installation Instructions

1.  Clone the repository:

    ```bash
    git clone https://github.com/muhammadabdelgawad/Survey-Basket.git
    ```

2.  Navigate to the `SurveyBasket.Api` directory:

    ```bash
    cd SurveyBasket.Api
    ```

3.  Update the database connection string in `appsettings.json`.  Find the `ConnectionStrings` section and set `DefaultConnection` to your SQL Server instance. Example:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=SurveyBasketDb;User Id=your_user_id;Password=your_password;TrustServerCertificate=true"
      },
      "Jwt": {
        "Key": "YourSuperSecretKeyHere",
        "Issuer": "https://localhost:7070",
        "Audience": "https://localhost:7070",
        "DurationInMinutes": 60
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```
    **Important:** Replace `your_server`, `SurveyBasketDb`, `your_user_id`, and `your_password` with your actual SQL Server credentials.  Also replace `YourSuperSecretKeyHere` with your own secret key for JWT.
4.  Apply the database migrations:

    ```bash
    dotnet ef database update -p ../SurveyBasket.Infrastructure/SurveyBasket.Infrastructure.csproj -s SurveyBasket.Api.csproj
    ```

5.  Build and run the API:

    ```bash
    dotnet run -p SurveyBasket.Api.csproj
    ```

## Usage Guide

### Authentication

1.  **Login:**

    *   Endpoint: `POST /auth`
    *   Request Body (JSON):

        ```json
        {
          "email": "user@example.com",
          "password": "password"
        }
        ```

    *   Response (JSON):

        ```json
        {
          "id": "user_id",
          "email": "user@example.com",
          "firstName": "John",
          "lastName": "Doe",
          "token": "jwt_token",
          "expiresIn": 3600,
          "refreshToken": "refresh_token",
          "refreshTokenExpiration": "2025-10-21T12:00:00"
        }
        ```

2.  **Refresh Token:**

    *   Endpoint: `POST /auth/refresh`
    *   Request Body (JSON):

        ```json
        {
          "token": "jwt_token",
          "refreshToken": "refresh_token"
        }
        ```

    *   Response (JSON): Same as login response.

3.  **Revoke Refresh Token:**

    *   Endpoint: `POST /auth/revoke-refresh-token`
    *   Request Body (JSON):

        ```json
        {
          "token": "jwt_token",
          "refreshToken": "refresh_token"
        }
        ```

    *   Response: `200 OK` on success, `400 Bad Request` on failure.

### Polls

1.  **Get All Polls:**

    *   Endpoint: `GET /api/polls`
    *   Authentication: Requires a valid JWT token in the `Authorization` header (Bearer scheme).

2.  **Get Poll by ID:**

    *   Endpoint: `GET /api/polls/{id}`
    *   Authentication: Requires a valid JWT token.

3.  **Add Poll:**

    *   Endpoint: `POST /api/polls`
    *   Authentication: Requires a valid JWT token.
    *   Request Body (JSON):

        ```json
        {
          "title": "Sample Poll",
          "summary": "This is a sample poll description.",
          "startsAt": "2025-10-21",
          "endsAt": "2025-10-28"
        }
        ```

4.  **Update Poll:**

    *   Endpoint: `PUT /api/polls/{id}`
    *   Authentication: Requires a valid JWT token.
    *   Request Body (JSON): Same as add poll request.

5.  **Delete Poll:**

    *   Endpoint: `DELETE /api/polls/{id}`
    *   Authentication: Requires a valid JWT token.

6.  **Toggle Publish Status:**

    *   Endpoint: `PUT /api/polls/{id}/togglePublish`
    *   Authentication: Requires a valid JWT token.

## API Documentation

The API documentation is generated using Swagger.  After running the application, you can access the Swagger UI at `https://localhost:{port}/swagger/index.html`, where `{port}` is the port number the application is running on (e.g., 7070).  Refer to the generated Swagger documentation for a complete list of endpoints, request parameters, and response schemas.

## Contributing Guidelines

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes, ensuring code quality and adding relevant tests.
4.  Submit a pull request with a clear description of your changes.

