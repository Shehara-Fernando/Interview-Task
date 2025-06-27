using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using TaskManagement.Domain.Entities;
using Taskmanagement.Application.Handlers.Interfaces;
using TaskManagement.Domain.Constants;

namespace Task_Management.Infrastructure.HttpServices

{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;
        public PokeApiService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            var url = $"{AppConstants.PokemonApi.BaseUrl}{string.Format(AppConstants.PokemonApi.Endpoints.PokemonById, id)}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            return new Pokemon
            {
                Id = doc.RootElement.GetProperty("id").GetInt32(),
                Name = doc.RootElement.GetProperty("name").GetString(),
                Height = doc.RootElement.GetProperty("height").GetInt32(),
                Weight = doc.RootElement.GetProperty("weight").GetInt32()
            };
        }
        //GenAI
        public async Task<List<Pokemon>> GetAllPokemonAsync(int limit)
        {
            var pokemons = new List<Pokemon>();
            var url = $"{AppConstants.PokemonApi.BaseUrl}{AppConstants.PokemonApi.Endpoints.Pokemon}?limit={limit}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return pokemons;
            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);
            foreach (var item in doc.RootElement.GetProperty("results").EnumerateArray())
            {
                var pokemonUrl = item.GetProperty("url").GetString();
                var pokeResp = await _httpClient.GetAsync(pokemonUrl);
                if (!pokeResp.IsSuccessStatusCode) continue;
                var pokeJson = await pokeResp.Content.ReadAsStringAsync();
                var pokeDoc = JsonDocument.Parse(pokeJson);
                pokemons.Add(new Pokemon
                {
                    Id = pokeDoc.RootElement.GetProperty("id").GetInt32(),
                    Name = pokeDoc.RootElement.GetProperty("name").GetString(),
                    Height = pokeDoc.RootElement.GetProperty("height").GetInt32(),
                    Weight = pokeDoc.RootElement.GetProperty("weight").GetInt32()
                });
            }
            return pokemons;
        }
    }
}
