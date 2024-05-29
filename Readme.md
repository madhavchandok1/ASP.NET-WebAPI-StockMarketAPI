# Stock Market API

## Overview

The Stock Market API is an ASP.NET Core WebAPI application that provides endpoints for managing stocks, comments, accounts, and more. This API is designed to help users interact with stock market data efficiently.

## Features

- **Stocks Controller**: Manage stock data including creating, updating, and retrieving stock information.
- **Comments Controller**: Handle comments related to stocks.
- **Accounts Controller**: Manage user accounts, authentication, and authorization.
- Other utility endpoints to support the application.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger for API documentation

## Getting Started

### Prerequisites

- .NET SDK 6.0 or later
- SQL Server
- Visual Studio or any other preferred IDE
- Git

### Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/your-username/stock-market-api.git
    cd stock-market-api
    ```

2. **Set up the database**:
    - Ensure SQL Server is running.
    - Update the `appsettings.json` file with your SQL Server connection string.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=your_server;Database=StockMarketDb;User Id=your_user;Password=your_password;"
    }
    ```

3. **Run database migrations**:
    ```sh
    dotnet ef database update
    ```

4. **Run the application**:
    ```sh
    dotnet run
    ```

5. **Open in a browser**:
    - Navigate to `https://localhost:5001/swagger` to view the API documentation.

## Usage

### Endpoints

Here are some of the main endpoints provided by the API:

- **Stocks Controller**:
  - `GET /api/stocks`: Get all stocks.
  - `GET /api/stocks/{id}`: Get a specific stock by ID.
  - `POST /api/stocks`: Create a new stock.
  - `PUT /api/stocks/{id}`: Update an existing stock.
  - `DELETE /api/stocks/{id}`: Delete a stock.

- **Comments Controller**:
  - `GET /api/comments`: Get all comments.
  - `GET /api/comments/{id}`: Get a specific comment by ID.
  - `POST /api/comments`: Create a new comment.
  - `PUT /api/comments/{id}`: Update an existing comment.
  - `DELETE /api/comments/{id}`: Delete a comment.

- **Accounts Controller**:
  - `POST /api/accounts/register`: Register a new user.
  - `POST /api/accounts/login`: Login a user and receive a JWT token.

### Sample Requests

#### Get all stocks

```sh
curl -X GET "https://localhost:5001/api/stocks" -H "accept: application/json"
