using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Strategies
{
    public class PokemonByIdStrategy:ISearchStrategy<int>, ISearchStrategy
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonByIdStrategy(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        //public bool CanHandle(string criteria)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<PokemonDetails> SearchAsync(int id)
        {
            var pokemon = _pokemonRepository.GetPokemonBySearchAsync(id);
            return pokemon;
        }

        public async Task<PokemonDetails> SearchAsync(string id)
        {
            var pokemon = await _pokemonRepository.GetPokemonBySearchAsync(id);
            return pokemon;
        }
    }
}
