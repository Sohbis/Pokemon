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
    public class PokemonByIdStrategy:ISearchStrategy
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonByIdStrategy(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        //public string StrategyName => ApplicationConstant.POKEMONBYIDSEARCH;

        public SearchCriteriaType StrategyName => SearchCriteriaType.ById;

        //public bool CanHandle(string criteria)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<PokemonDetails> SearchAsync(PokemonSearchRequest request)
        {
            var pokemon = await _pokemonRepository.GetPokemonBySearchAsync(request.Id!.Value);
            if (pokemon == null)
            {
                throw new ArgumentException("No Pokemon found with this Id");
            }
            return pokemon;
        }

        //public async Task<PokemonDetails> SearchAsync(string id)
        //{
        //    var pokemon = await _pokemonRepository.GetPokemonBySearchAsync(id);
        //    return pokemon;
        //}
    }
}
