# VidyaMitra

A comprehensive .NET-based educational management system built with a clean architecture approach.

## Project Structure

The solution is organized into four main layers:

- **VidyaMitra.API**: REST API layer built with ASP.NET Core
- **VidyaMitra.Application**: Application/Business logic layer with DTOs and interfaces
- **VidyaMitra.Domain**: Domain entities and core business models
- **VidyaMitra.Repository**: Data access layer with repositories and database context

## Prerequisites

- .NET 10.0 SDK or later
- A supported database (configured via Entity Framework Core)

## Getting Started

1. Clone the repository:
```bash
git clone <repository-url>
cd VidyaMitra
```

2. Build the solution:
```bash
dotnet build
```

3. Run the API:
```bash
cd VidyaMitra.API
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`

## Project Features

- Student management
- Course management
- Enrollment tracking
- Professor management
- Department organization
- Grade management
- Authentication and authorization with JWT

## API Documentation

API endpoints are documented in `VidyaMitra.API/VidyaMitra.API.http` file which can be used with REST clients.

## Contributing

Please ensure all code follows the established architectural patterns and includes appropriate error handling.

## License

This project is part of the VidyaMitra educational management system.
