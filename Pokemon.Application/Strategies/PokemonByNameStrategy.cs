using Pokemon.Application.Constants;
using Pokemon.Application.Models;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using Pokemon.Domain.Enums;
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

        public PokemonByNameStrategy(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        //public string StrategyName => ApplicationConstant.POKEMONBYNAMESEARCH;

        public SearchCriteriaType StrategyName => SearchCriteriaType.ByName;

        public async Task<PokemonDetails> SearchAsync(PokemonSearchRequest request)
        {
            var pokemon = await _pokemonRepository.GetPokemonBySearchAsync(request.Name);
            //if (pokemon == null)
            //{
            //    throw new ArgumentException("No Pokemon found with this name");
            //}
            return pokemon;
        }
    }
}
