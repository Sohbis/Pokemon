using Pokemon.Application.Common.Interfaces;
using Pokemon.Application.DTOs;
using Pokemon.Application.Models;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Application.Factories;

namespace Pokemon.Application.Services
{
    public class PokemonService : IPokemonService
    {
        //private readonly IPokemonRepository _pokemonRepository;

        private readonly SearchStrategyFactory _searchStrategyFactory;
        public PokemonService(IPokemonRepository pokemonRepository, SearchStrategyFactory searchStrategyFactory)
        {
            //_pokemonRepository = pokemonRepository;
            _searchStrategyFactory = searchStrategyFactory;
        }

        public IEnumerable<PokemonListItemDto> GetPokemonsAsync()
        {

            var list = new List<PokemonListItemDto>
            {
                new PokemonListItemDto{

                Name="Bulbasaur",
                Order=1,
                Abilities="Overgrow, Chlorophyll",
                Type="Grass/Poison"
                }
             };
            return list;
        }

        //public Task<PokemonSearchDto> PokemonBySearchAsync<T>(T searchCriteria)
        //{
        //    var searchedPokemon = _pokemonRepository.GetPokemonBySearchAsync(searchCriteria);

        //    //PokemonSearchDto pokemon = new PokemonSearchDto { Name = "Bulbasaur", ImgUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png" };

        //    PokemonSearchDto pokemon = new PokemonSearchDto()
        //    { Name = searchedPokemon.Result.PokemonName, ImgUrl = searchedPokemon.Result.PokemonSprites };
        //    return Task.FromResult(pokemon);
        //}

        //public async Task<PokemonSearchDto> PokemonBySearchAsync<T>(T searchCriteria)
        //{
        //    var searchStrategy = _searchStrategyFactory.GetSearchStrategy(searchCriteria.ToString());
        //    var pokemon = await searchStrategy.SearchAsync(searchCriteria.ToString());
        //    PokemonSearchDto searchedPokemon = new()
        //    {
        //        Name = pokemon.PokemonName,
        //        ImgUrl = pokemon.PokemonSprites,
        //    };

        //    return searchedPokemon;
        //}

        public async Task<PokemonSearchDto> PokemonBySearchAsync(PokemonSearchRequest searchCriteria)
        {
            var strategy = _searchStrategyFactory.GetSearchStrategy(searchCriteria);
            var pokemon = await strategy.SearchAsync(searchCriteria);
            PokemonSearchDto searchedPokemon = new()
            {
                Name = pokemon.PokemonName,
                ImgUrl = pokemon.PokemonSprites,
            };

            return searchedPokemon;
        }
    }
}
