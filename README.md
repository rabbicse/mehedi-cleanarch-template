# Clean Architecture Template

A modular and scalable Clean Architecture template for .NET projects. This template follows industry best practices for structuring .NET applications, making development more maintainable and testable.

## Features

- **Clean Architecture**: Separation of concerns with modular layers.
- **.NET 8**: Built with the latest .NET framework.
- **CQRS & Mediator Pattern**: Uses MediatR for better request handling.
- **Dependency Injection**: Follows best practices for IoC.
- **Unit Testing**: Pre-configured with xUnit and Moq.
- **Database Support**: Works with Entity Framework Core and supports SQL Server and PostgreSQL.
- **Docker Support**: Includes Dockerfile for easy deployment.
- **Authentication & Authorization**: JWT-based authentication.
- **Swagger UI**: Integrated for API documentation.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Docker (optional)
- SQL Server or PostgreSQL (if using EF Core)

### Installation

1. **Clone the Repository**
   ```sh
   git clone https://github.com/rabbicse/mehedi-cleanarch-template.git
   cd mehedi-cleanarch-template
   ```

2. **Restore Dependencies**
   ```sh
   dotnet restore
   ```

3. **Update Database (if using EF Core)**
   ```sh
   dotnet ef database update
   ```

4. **Run the Application**
   ```sh
   dotnet run
   ```

### Running with Docker

1. **Build Docker Image**
   ```sh
   docker build -t cleanarch-template .
   ```

2. **Run the Container**
   ```sh
   docker run -p 5000:5000 cleanarch-template
   ```

## Project Structure

```
Mehedi.CleanArch.Template/
│-- src/
│   ├── Application/     # Business logic, use cases, MediatR handlers
│   ├── Domain/          # Entities, Aggregates, Value Objects
│   ├── Infrastructure/  # Database, Repositories, External services
│   ├── API/             # ASP.NET Core API project
│-- tests/
│   ├── UnitTests/       # Unit tests for business logic
│   ├── IntegrationTests/# Integration tests
│-- Dockerfile           # Docker configuration
│-- README.md            # Project documentation
```

# Clean Architecture Template
A .NET 8 Clean Architecture template for building scalable and maintainable applications, following best practices with Domain-Driven Design (DDD), Event-Driven Architecture (EDA), CQRS, JWT Authentication, EF Core, and Docker support.

## List all templates
List all the dotnet core templates with the following command.
```bash
dotnet new list
```

## Create New project
Write the following command to create new .NET project with `cleanarch` template.
```bash
dotnet new cleanarch -n MyProject
```

## Contributing

Contributions are welcome! Feel free to submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any inquiries, reach out to [Mehedi](https://github.com/rabbicse).

## References
- [dotnet-runtime](https://github.com/dotnet/runtime)
