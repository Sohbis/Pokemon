using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Strategies
{
    public class PokemonByNameStrategy : ISearchStrategy, ISearchStrategy<string>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonByNameStrategy(IPokemonRepository pokemonRepository )
        {
            _pokemonRepository = pokemonRepository;
        }
        public Task<PokemonDetails> SearchAsync(string name)
        {
            var pokemon = _pokemonRepository.GetPokemonBySearchAsync(name);
            return pokemon;
        }
    }
}
