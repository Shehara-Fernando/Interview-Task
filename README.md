# AppConstants Static Class

This static class contains all the API addresses and SQL queries used throughout the application. It provides a centralized location for managing configuration constants.

## Project Overview

This is a .NET 8 Web API project that demonstrates a clean architecture pattern with the following layers:
- **Domain Layer**: Contains entities, interfaces, and constants
- **Application Layer**: Contains business logic and services
- **Infrastructure Layer**: Contains data access and external service implementations
- **Web API Layer**: Contains controllers and API endpoints

## Frameworks and Libraries Used

### Core Framework
- **.NET 8**: The latest LTS version of .NET, providing modern features like:
  - Improved performance and memory management
  - Enhanced async/await patterns
  - Better dependency injection
  - Modern C# language features

### Web API Framework
- **ASP.NET Core**: Microsoft's cross-platform web framework
  - Built-in dependency injection
  - Middleware pipeline for request/response processing
  - Built-in support for JSON serialization/deserialization
  - Swagger/OpenAPI integration for API documentation

### Database Access
- **Microsoft.Data.SqlClient (v6.0.2)**: Modern SQL Server client library
  - **Decision**: Chosen over System.Data.SqlClient for better performance, security, and .NET 8 compatibility
  - Supports async/await patterns
  - Better parameter handling and SQL injection prevention
  - Enhanced connection pooling and resilience

### HTTP Client
- **System.Net.Http.HttpClient**: Built-in HTTP client for making external API calls
  - **Decision**: Used with IHttpClientFactory for proper lifecycle management
  - Prevents socket exhaustion issues
  - Supports dependency injection and configuration
  - Built-in support for JSON handling

### JSON Processing
- **System.Text.Json**: Built-in JSON library
  - **Decision**: Chosen over Newtonsoft.Json for better performance and .NET integration
  - Native async support
  - Better memory efficiency
  - Built-in support in ASP.NET Core

### API Documentation
- **Swashbuckle.AspNetCore (v6.5.0)**: Swagger/OpenAPI implementation
  - **Decision**: Industry standard for API documentation
  - Interactive API testing interface
  - Automatic documentation generation from code
  - Supports OpenAPI 3.0 specification

### Security
- **System.Security.Permissions (v9.0.6)**: Security permissions library
  - **Decision**: Required for SQL Server connections in .NET 8
  - Provides necessary security context for database operations
  - Ensures proper permission handling

## Architecture Decisions

### Clean Architecture Pattern
- **Separation of Concerns**: Each layer has a specific responsibility
- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Testability**: Easy to unit test each layer independently
- **Maintainability**: Clear structure makes the codebase easier to maintain

### Static Constants Class
- **Centralized Configuration**: All API endpoints and SQL queries in one place
- **Type Safety**: Compile-time checking prevents runtime errors
- **IntelliSense Support**: Better developer experience with autocomplete
- **Easy Maintenance**: Single point of change for configuration updates

### Repository Pattern
- **Data Access Abstraction**: Business logic doesn't depend on specific data access technology
- **Testability**: Easy to mock repositories for unit testing
- **Flexibility**: Can easily switch between different data sources

### Service Layer Pattern
- **Business Logic Encapsulation**: All business rules are in the service layer
- **Reusability**: Services can be used by multiple controllers
- **Testability**: Business logic can be tested independently of the web layer

## Structure

### API Endpoints


#### PokemonApi
- `BaseUrl`: The base URL for the Pokemon API
- `Endpoints`: Contains all Pokemon API endpoint paths
  - `Pokemon`: Pokemon list endpoint
  - `PokemonById`: Pokemon by ID endpoint (uses string.Format with {0} placeholder)

### SQL Queries

#### Pokemon
- `GetById`: SQL query to get a Pokemon by ID
- `GetAll`: SQL query to get all Pokemon
- `Insert`: SQL query to insert a new Pokemon

### Connection Strings

- `DefaultConnection`: The name of the default connection string in appsettings.json

## Usage Examples

### Using API Constants
```csharp


// Pokemon API
var url = $"{AppConstants.PokemonApi.BaseUrl}{string.Format(AppConstants.PokemonApi.Endpoints.PokemonById, id)}";
```

### Using SQL Constants
```csharp
var cmd = new SqlCommand(AppConstants.SqlQueries.Pokemon.GetById, conn);
var cmd = new SqlCommand(AppConstants.SqlQueries.Pokemon.GetAll, conn);
var cmd = new SqlCommand(AppConstants.SqlQueries.Pokemon.Insert, conn);
```

### Using Connection String Constants
```csharp
var connectionString = configuration.GetConnectionString(AppConstants.ConnectionStrings.DefaultConnection);
```

## Benefits

1. **Centralized Configuration**: All constants are in one place
2. **Easy Maintenance**: Changes only need to be made in one location
3. **Type Safety**: Compile-time checking for constant usage
4. **IntelliSense Support**: Better IDE support with autocomplete
5. **Consistency**: Ensures consistent usage across the application
6. **Documentation**: Self-documenting code with clear naming conventions

## Adding New Constants

When adding new API endpoints or SQL queries:

1. Add them to the appropriate section in `AppConstants`
2. Use clear, descriptive names
3. Group related constants together
4. Add comments if needed for clarity
5. Update this README if adding new sections

## Performance Considerations

- **Connection Pooling**: SQL Server connections are pooled for better performance
- **Async/Await**: All I/O operations are async to prevent thread blocking
- **HTTP Client Factory**: Properly managed HTTP clients prevent socket exhaustion
- **JSON Serialization**: System.Text.Json provides better performance than Newtonsoft.Json

## Security Considerations

- **SQL Injection Prevention**: All SQL queries use parameterized queries
- **API Key Management**: API keys are stored in constants (consider moving to configuration for production)
- **HTTPS**: Application is configured to use HTTPS in production
- **Input Validation**: All user inputs should be validated before processing 
