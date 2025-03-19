[![Build](https://github.com/rabbicse/mehedi-cleanarch-template/actions/workflows/publish-template.yml/badge.svg)](https://github.com/rabbicse/mehedi-cleanarch-template/actions/workflows/publish-template.yml)
[![CodeQL](https://github.com/rabbicse/mehedi-cleanarch-template/actions/workflows/codeql.yml/badge.svg)](https://github.com/rabbicse/mehedi-cleanarch-template/actions/workflows/codeql.yml)
[![Nuget](https://img.shields.io/nuget/v/Mehedi.CleanArchitecture.Template)](https://www.nuget.org/packages/Mehedi.CleanArchitecture.Template/)
[![Nuget](https://img.shields.io/nuget/dt/Mehedi.CleanArchitecture.Template)](https://www.nuget.org/packages/Mehedi.CleanArchitecture.Template/)

# .NET Core Clean Architecture Template

The goal of this template is to provide a straightforward and efficient approach to enterprise API development, leveraging the power of Clean Architecture and ASP.NET Core. Using this template, you can effortlessly create scalable and maintainable APIs while adhering to Clean Architecture principles.

Getting started is easy—simply install the .NET template (see below for full details).

If you find this project useful, please give it a star. Thanks! ⭐

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
- Docker
- SQL Server or PostgreSQL

## Project Structure

```
Mehedi.CleanArch.Template/
│-- src/
│   ├── Application/     # Business logic, use cases, MediatR handlers
│   ├── Domain/          # Entities, Aggregates, Value Objects
│   ├── Infrastructure/  # Database, Repositories, External services
│   ├── Presentation/             # ASP.NET Core API project
│      │-- Dockerfile           # Docker configuration
│-- tests/
│   ├── UnitTests/       # Unit tests for business logic
│   ├── IntegrationTests/# Integration tests
│-- README.md            # Project documentation
```

## Installation & Getting Started
### List all templates
List all the dotnet core templates with the following command.
```bash
dotnet new list
```

### Install **cleanarch** template
```bash
dotnet new install Mehedi.CleanArchitecture.Template
```

### Create New project
Write the following command to create new .NET project with `cleanarch` template.
```bash
dotnet new cleanarch -n MyProject -D postgresql
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
- [ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture)
- [jasontaylordev/CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture)
