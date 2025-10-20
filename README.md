# Survey-Basket

## Description

This project is a .NET API for managing polls/surveys. It provides functionalities for creating, retrieving, updating, and deleting polls, as well as managing user authentication and authorization using JWT and refresh tokens.

## Features and Functionality

-   **Poll Management:**
    -   Create new polls with a title, summary, start date, and end date.
    -   Retrieve poll details by ID.
    -   List all polls.
    -   Update existing poll information.
    -   Delete polls.
    -   Toggle the publish status of a poll.
-   **Authentication and Authorization:**
    -   User registration and login.
    -   JWT-based authentication for secure API access.
    -   Refresh token mechanism for maintaining user sessions.
    -   Token revocation for enhanced security.
-   **Data Validation:**
    -   FluentValidation for request validation.
-   **API Documentation:**
    -   Swagger/OpenAPI integration for interactive API documentation.
-   **Auditing:**
    -   Tracks creation and update information for Poll entities.


## Technology Stack

-   .NET 9.0
-   ASP.NET Core API
-   Entity Framework Core (with SQL Server)
-   Microsoft Identity
-   JWT (JSON Web Tokens)
-   FluentValidation
-   Mapster
-   Swagger/OpenAPI
-   C# 12

## Prerequisites

-   .NET SDK 9.0 or later
-   SQL Server instance
-   An IDE such as Visual Studio or VS Code.

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Survey-Basket.git
    cd Survey-Basket
    ```

2.  **Configure the database connection:**

    -   Open the `SurveyBasket.Api/appsettings.json` file.
    -   Modify the `ConnectionStrings.DefaultConnection` value to point to your SQL Server instance.  For example:

    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=SurveyBasketDB;User Id=your_user_id;Password=your_password;TrustServerCertificate=True"
    },
    ...
    }
    ```

3.  **Apply Entity Framework Core Migrations:**

    ```bash
    cd SurveyBasket.Api
    dotnet ef database update
    ```

4.  **Configure JWT Settings**
    - Open `SurveyBasket.Api/appsettings.json` file
    - Add JWT Settings as follows:

    ```json
        "Jwt": {
            "Key": "Your_Super_Secret_Key",
            "Issuer": "SurveyBasketAPI",
            "Audience": "SurveyBasketFrontend",
            "DurationInMinutes": 60
        }
    ```

5.  **Build and Run the application:**

    ```bash
    dotnet build
    dotnet run
    ```

    The API will be accessible at `https://localhost:<port>`, where `<port>` is the port number configured in your launch settings (typically 5001).

## Usage Guide

### Authentication

1.  **Register a User:**
    -   Use a tool like Postman or SwaggerUI to send a POST request to the `/register` endpoint (Note: there is no register endpoint currently implimented, you have to manually add users in the database).  You must manually add users through the database or create a register endpoint.

2.  **Login:**
    -   Send a POST request to the `/Auth` endpoint with the `Email` and `Password` in the request body.

    ```json
    {
    "email": "test@example.com",
    "password": "P@sswOrd"
    }
    ```

    -   The API will return an `AuthResponse` object containing the JWT token, expiration time, and refresh token:

    ```json
    {
        "Id": "your_user_id",
        "Email": "test@example.com",
        "FirstName": "Test",
        "LastName": "User",
        "Token": "your_jwt_token",
        "ExpiresIn": 3600,
        "RefreshToken": "your_refresh_token",
        "RefreshTokenExpiration": "2025-11-02T14:30:00.000Z"
    }
    ```

3.  **Accessing Protected Endpoints:**
    -   Include the JWT token in the `Authorization` header of your requests, using the `Bearer` scheme:

    ```
    Authorization: Bearer your_jwt_token
    ```

4.  **Refreshing the Token:**
    -   Send a POST request to `/Auth/refresh` endpoint with the JWT `Token` and `RefreshToken` in the request body.

    ```json
    {
    "token": "expired_jwt_token",
    "refreshToken": "used_refresh_token"
    }
    ```

5.  **Revoking Refresh Token:**

    -  Send a POST request to `/Auth/revoke-refresh-token` with the JWT `Token` and `RefreshToken` in the request body to invalidate the refresh token.

    ```json
    {
        "token": "current_jwt_token",
        "refreshToken": "refresh_token_to_revoke"
    }
    ```

### Poll Management

1.  **Get All Polls:**
    -   Send a GET request to `/api/Polls`.

2.  **Get Poll by ID:**
    -   Send a GET request to `/api/Polls/{id}`, replacing `{id}` with the ID of the poll you want to retrieve.

3.  **Create a New Poll:**
    -   Send a POST request to `/api/Polls` with the following JSON body:

    ```json
    {
    "title": "Sample Poll",
    "summary": "This is a sample poll description.",
    "startsAt": "2024-01-01",
    "endsAt": "2024-01-15"
    }
    ```

4.  **Update a Poll:**
    -   Send a PUT request to `/api/Polls/{id}`, replacing `{id}` with the ID of the poll you want to update.  Include the updated poll data in the request body in the same format as the create poll request.

    ```json
    {
    "title": "Updated Sample Poll",
    "summary": "This is an updated sample poll description.",
    "startsAt": "2024-02-01",
    "endsAt": "2024-02-15"
    }
    ```

5.  **Delete a Poll:**
    -   Send a DELETE request to `/api/Polls/{id}`, replacing `{id}` with the ID of the poll you want to delete.

6.  **Toggle Publish Status:**
     -  Send a PUT request to `/api/Polls/{id}/togglePublish`, replacing `{id}` with the ID of the poll you want to update.


## API Documentation

The API documentation is available through Swagger UI. Once the application is running, you can access it by navigating to `https://localhost:<port>/swagger/index.html` in your browser. This interface allows you to explore the available endpoints, view request and response schemas, and make API calls directly from your browser. You can also access the OpenAPI definition at `https://localhost:<port>/openapi/v1.json`.

## Contributing Guidelines

Contributions are welcome! To contribute to this project, please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Write tests to cover your changes.
5.  Ensure that all tests pass.
6.  Submit a pull request.
