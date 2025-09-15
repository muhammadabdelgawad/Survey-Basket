# SurveyBasket

A simple ASP.NET Core Web API for managing polls.

## Features and Functionality

This API allows you to:

*   Retrieve a list of all polls.
*   Retrieve a specific poll by its ID.
*   Create a new poll.
*   Update an existing poll.
*   Delete a poll.

## Technology Stack

*   ASP.NET Core
*   C#
*   .NET 9 (Implicitly based on Program.cs and general best practices)
*   Swagger/OpenAPI for API documentation

## Prerequisites

*   .NET SDK 9.0 or higher
*   An IDE or text editor (e.g., Visual Studio, Visual Studio Code, Rider)

## Installation Instructions

1.  Clone the repository:

    ```bash
    git clone https://github.com/muhammadabdelgawad/SurveyBasket.git
    ```

2.  Navigate to the `SurveyBasket.Api` directory:

    ```bash
    cd SurveyBasket.Api
    ```

3.  Restore NuGet packages:

    ```bash
    dotnet restore
    ```

4.  Build the project:

    ```bash
    dotnet build
    ```

## Usage Guide

1.  Run the application:

    ```bash
    dotnet run
    ```

2.  Access the API endpoints using a tool like Postman, Insomnia, or Swagger UI.  Swagger UI is enabled by default in development mode.

    *   In your browser, navigate to `https://localhost:<port>/swagger/index.html` or `http://localhost:<port>/swagger/index.html` (depending on your HTTPS configuration) to view the Swagger UI. The port number will be displayed in the console when the application starts.

## API Documentation

The API exposes the following endpoints:

**PollsController.cs** located in the `/SurveyBasket.Api/Controllers` folder implements the following Endpoints.

*   **GET `/api/Polls`**: Retrieves all polls.
    *   Response:
        ```json
        [
            {
                "id": 1,
                "tittle": "Poll 1",
                "description": "This is my first poll"
            }
        ]
        ```

*   **GET `/api/Polls/{id}`**: Retrieves a poll by ID.
    *   Parameters:
        *   `id` (integer): The ID of the poll to retrieve.
    *   Response:
        ```json
        {
            "id": 1,
            "tittle": "Poll 1",
            "description": "This is my first poll"
        }
        ```
    *   Returns a 404 Not Found if the poll does not exist.

*   **POST `/api/Polls`**: Creates a new poll.
    *   Request body (JSON): Located in `SurveyBasket.Api/Contracts/Requests/CreatePollRequest.cs`
        ```json
        {
            "tittle": "New Poll Title",
            "description": "New Poll Description"
        }
        ```
    *   Response:
        *   201 Created - Returns the newly created poll with its ID in the `Location` header.  The response body will contain the newly created poll.
        ```json
           {
                "id": 2,
                "tittle": "New Poll Title",
                "description": "New Poll Description"
            }
        ```

*   **PUT `/api/Polls/{id}`**: Updates an existing poll.
    *   Parameters:
        *   `id` (integer): The ID of the poll to update.
    *   Request body (JSON): Located in `SurveyBasket.Api/Contracts/Requests/CreatePollRequest.cs`
        ```json
        {
            "tittle": "Updated Poll Title",
            "description": "Updated Poll Description"
        }
        ```
    *   Response:
        *   204 No Content - Returns a 204 status code on success.
    *   Returns a 404 Not Found if the poll does not exist.

*   **DELETE `/api/Polls/{id}`**: Deletes a poll.
    *   Parameters:
        *   `id` (integer): The ID of the poll to delete.
    *   Response:
        *   204 No Content - Returns a 204 status code on success.
    *   Returns a 404 Not Found if the poll does not exist.

**Request and Response Contracts:**

The request and response objects are defined in the `SurveyBasket.Api/Contracts` directory.
*   `CreatePollRequest.cs` defines the request body for creating a poll.
*   `PollResponse.cs` defines the structure of the poll response.

**Mappings**

The `SurveyBasket.Api/Mapping/ContractMapping.cs` defines extension methods for mapping between the `Poll` model and the request and response contracts.

## Contributing Guidelines

Contributions are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with descriptive messages.
4.  Submit a pull request.

## License Information

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

