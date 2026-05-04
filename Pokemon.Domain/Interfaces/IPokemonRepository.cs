using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;

namespace Pokemon.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        public Task<IEnumerable<PokemonList>> GetPokemonListAsync();
        public Task<PokemonDetails> GetPokemonBySearchAsync<T>(T searchCriteria);
        public Task<PokemonDetails> GetPokemonByNameAsync();

    }
}
