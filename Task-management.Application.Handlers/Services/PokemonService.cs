using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Handlers.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace Taskmanagement.Application.Handlers.Services
{
    public class PokemonService
    {
        private readonly IPokemonRepository _repo;
        private readonly IPokeApiService _api;
        public PokemonService(IPokemonRepository repo, IPokeApiService api)
        {
            _repo = repo;
            _api = api;
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            var pokemon = await _repo.GetByIdAsync(id);
            if (pokemon != null) return pokemon;
            pokemon = await _api.GetPokemonAsync(id);
            if (pokemon != null) await _repo.AddAsync(pokemon);
            return pokemon;
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            var pokemons = await _repo.GetAllAsync();
            if (pokemons.Count > 0)
                return pokemons;

            var apiPokemons = await _api.GetAllPokemonAsync(100); 
            foreach (var p in apiPokemons)
                await _repo.AddAsync(p);

            return apiPokemons;
        }
    }
}
