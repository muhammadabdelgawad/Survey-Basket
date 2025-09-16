# Survey-Basket

## Description

This is a simple ASP.NET Core Web API for managing polls. It provides endpoints for creating, reading, updating, and deleting polls.

## Features and Functionality

*   **Get All Polls:** Retrieves a list of all polls.
*   **Get Poll by ID:** Retrieves a specific poll by its ID.
*   **Add Poll:** Creates a new poll.
*   **Update Poll:** Updates an existing poll.
*   **Delete Poll:** Deletes a poll.
*   **Input Validation:** Uses FluentValidation to validate poll creation and update requests.

## Technology Stack

*   **ASP.NET Core:** Web framework.
*   **C#:** Programming language.
*   **.NET 8 (Assumed):** .NET runtime.
*   **Mapster:** Object-to-object mapper.
*   **FluentValidation:** Validation library.
*   **Swagger/OpenAPI:** API documentation.

## Prerequisites

*   [.NET SDK](https://dotnet.microsoft.com/en-us/download) (version 8 or later, assumed)
*   An IDE such as Visual Studio or VS Code.

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Survey-Basket.git
    cd Survey-Basket
    ```

2.  **Navigate to the `SurveyBasket.Api` directory:**

    ```bash
    cd SurveyBasket.Api
    ```

3.  **Restore NuGet packages:**

    ```bash
    dotnet restore
    ```

4.  **Build the project:**

    ```bash
    dotnet build
    ```

## Usage Guide

1.  **Run the application:**

    ```bash
    dotnet run
    ```

2.  **Access the Swagger UI:**

    Open your browser and navigate to `https://localhost:{port}/swagger/index.html`, where `{port}` is the port number your application is running on (typically 5001 for HTTPS or 5000 for HTTP, you can confirm this in the console output when running the application).

3.  **Use the API endpoints:**

    Use the Swagger UI to interact with the API endpoints or use a tool like Postman or curl.  Here are some examples:

    *   **Get All Polls:** `GET /api/Polls`
    *   **Get Poll by ID:** `GET /api/Polls/{id}`
    *   **Add Poll:** `POST /api/Polls`

        Request body example:

        ```json
        {
          "id": 0,
          "tittle": "My New Poll",
          "description": "This is a description of my new poll."
        }
        ```

    *   **Update Poll:** `PUT /api/Polls/{id}`

        Request body example:

        ```json
        {
          "id": 0,
          "tittle": "Updated Poll Title",
          "description": "Updated poll description."
        }
        ```

    *   **Delete Poll:** `DELETE /api/Polls/{id}`

## API Documentation

The API documentation is generated using Swagger/OpenAPI.  You can access it by navigating to `https://localhost:{port}/swagger/index.html` in your browser after running the application. The generated documentation describes all available endpoints, request/response formats, and status codes.

## Contributing Guidelines

Contributions are welcome! Here are the general guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with clear, concise messages.
4.  Submit a pull request.

Please ensure your code adheres to the existing coding style and includes appropriate unit tests.

