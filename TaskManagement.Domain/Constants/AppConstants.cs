namespace TaskManagement.Domain.Constants
{
    public static class AppConstants
    {
        #region API Endpoints
        
        // Pokemon API
        public static class PokemonApi
        {
            public const string BaseUrl = "https://pokeapi.co/api/v2/";
            
            public static class Endpoints
            {
                public const string Pokemon = "pokemon";
                public const string PokemonById = "pokemon/{0}";
            }
        }
        
        #endregion
        
        #region SQL Queries
        
        public static class SqlQueries
        {
            public static class Pokemon
            {
                public const string GetById = "SELECT Id, Name, Height, Weight FROM Pokemon WHERE Id = @Id";
                public const string GetAll = "SELECT Id, Name, Height, Weight FROM Pokemon";
                public const string Insert = "INSERT INTO Pokemon (Name, Height, Weight) VALUES (@Name, @Height, @Weight)";
            }
        }
        
        #endregion
        
        #region Connection Strings
        
        public static class ConnectionStrings
        {
            public const string DefaultConnection = "DefaultConnection";
        }
        
        #endregion
    }
} 