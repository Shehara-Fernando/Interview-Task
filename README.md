# AppConstants Static Class

This static class contains all the API addresses and SQL queries used throughout the application. It provides a centralized location for managing configuration constants.

## Structure

### API Endpoints

#### BasketballApi
- `BaseUrl`: The base URL for the basketball API
- `ApiKey`: The API key for authentication
- `ApiKeyHeader`: The header name for the API key
- `Endpoints`: Contains all basketball API endpoint paths
  - `Games`: Games endpoint
  - `LiveScore`: Live scores endpoint
  - `Teams`: Teams endpoint
  - `Standings`: Standings endpoint

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
// Basketball API
var url = $"{AppConstants.BasketballApi.BaseUrl}{AppConstants.BasketballApi.Endpoints.Games}";
request.Headers.Add(AppConstants.BasketballApi.ApiKeyHeader, AppConstants.BasketballApi.ApiKey);

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