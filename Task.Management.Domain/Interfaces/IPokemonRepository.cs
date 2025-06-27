using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public  interface IPokemonRepository
    {
        Task<Pokemon> GetByIdAsync(int id);
        Task<List<Pokemon>> GetAllAsync();
        System.Threading.Tasks.Task AddAsync(Pokemon pokemon);
       
    }
}
