using Pokemon.Application.Constants;
using Pokemon.Application.Models;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Strategies
{
    //public class PokemonByNameStrategy : ISearchStrategy, ISearchStrategy<string>
    public class PokemonByNameStrategy : ISearchStrategy
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonByNameStrategy(IPokemonRepository pokemonRepository )
        {
            _pokemonRepository = pokemonRepository;
        }

        public string StrategyName => ApplicationConstant.POKEMONBYIDSEARCH;
        public Task<PokemonDetails> SearchAsync(PokemonSearchRequest request)
        {
            var pokemon = _pokemonRepository.GetPokemonBySearchAsync(request.Name);
            return pokemon;
        }
    }
}
