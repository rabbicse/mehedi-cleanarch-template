[![Nuget](https://img.shields.io/nuget/v/Mehedi.CleanArchitecture.Template)](https://www.nuget.org/packages/Mehedi.CleanArchitecture.Template/)
[![Nuget](https://img.shields.io/nuget/dt/Mehedi.CleanArchitecture.Template)](https://www.nuget.org/packages/Mehedi.CleanArchitecture.Template/)

# .NET Core Clean Architecture Template

A modular and scalable Clean Architecture template for .NET projects. This template follows industry best practices for structuring .NET applications, making development more maintainable and testable.

## Features

- **Clean Architecture**: Separation of concerns with modular layers.
- **DDD**: Domain Driven Design.
- **.NET 8**: Built with the latest .NET framework.
- **CQRS & Mediator Pattern**: Uses MediatR for better request handling.
- **Dependency Injection**: Follows best practices for IoC.
- **Unit Testing**: Pre-configured with xUnit and Moq.
- **Database Support**: Works with Entity Framework Core and supports SQL Server and PostgreSQL.
- **Docker Support**: Includes Dockerfile for easy deployment.
- **Swagger UI**: Integrated for API documentation.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Docker (optional)
- SQL Server or PostgreSQL (if using EF Core)

## Project Structure

```
Mehedi.CleanArch.Template/
│-- src/
│   ├── Application/     # Business logic, use cases, MediatR handlers
│   ├── Domain/          # Entities, Aggregates, Value Objects
│   ├── Infrastructure/  # Database, Repositories, External services
│   ├── Presentation/             # ASP.NET Core API project
│-- tests/
│   ├── UnitTests/       # Unit tests for business logic
│   ├── IntegrationTests/# Integration tests
│-- Dockerfile           # Docker configuration
│-- README.md            # Project documentation
```

## Installation & Getting Started
### List all templates
List all the dotnet core templates with the following command.
```bash
dotnet new list
```

### Create New project
Write the following command to create new .NET project with `cleanarch` template.
```bash
dotnet new cleanarch -n MyProject
```

Then just run project with the following command.
```bash
dotnet run --project ./src/Presentation/MyProject.Api.csproj
```

## Contributing

Contributions are welcome! Feel free to submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

For any inquiries, reach out to [Mehedi](https://github.com/rabbicse).

## References
- [dotnet-runtime](https://github.com/dotnet/runtime)
