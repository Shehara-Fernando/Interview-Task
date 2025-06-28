using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace Taskmanagement.Application.Handlers.Interfaces
{
    public interface IPokeApiService
    {
        Task<Pokemon> GetPokemonAsync(int id);
        //GenAI
        Task<List<Pokemon>> GetAllPokemonAsync(int limit);
    }
}
