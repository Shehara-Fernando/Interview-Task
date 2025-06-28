using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using TaskManagement.Domain.Constants;

namespace TaskManagement.Infrastructure.Data.Repositories.Read
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly SqlConnectionFactory _factory;
        public PokemonRepository(SqlConnectionFactory factory) => _factory = factory;

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            using var conn = _factory.CreateConnection();
            await conn.OpenAsync();
            var cmd = new SqlCommand(AppConstants.SqlQueries.Pokemon.GetById, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Pokemon
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Height = reader.GetInt32(2),
                    Weight = reader.GetInt32(3)
                };
            }
            return null;
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            var result = new List<Pokemon>();
            using var conn = _factory.CreateConnection();
            await conn.OpenAsync();
            var cmd = new SqlCommand(AppConstants.SqlQueries.Pokemon.GetAll, conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Pokemon
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Height = reader.GetInt32(2),
                    Weight = reader.GetInt32(3)
                });
            }
            return result;
        }

        public async System.Threading.Tasks.Task AddAsync(Pokemon pokemon)
        {
            await using var conn = _factory.CreateConnection();
            await conn.OpenAsync();

            var cmd = conn.CreateCommand();
            cmd.CommandText = AppConstants.SqlQueries.Pokemon.Insert;
            cmd.Parameters.AddWithValue("@Name", pokemon.Name);
            cmd.Parameters.AddWithValue("@Height", pokemon.Height);
            cmd.Parameters.AddWithValue("@Weight", pokemon.Weight);

            await cmd.ExecuteNonQueryAsync();
        }

    }
}
