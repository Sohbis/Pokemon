using MediatR;
using Pokemon.Application.Common.Interfaces;
using Pokemon.Application.DTOs;
using Pokemon.Application.Factories;
using Pokemon.Application.Models;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Exceptions;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        private readonly SearchStrategyFactory _searchStrategyFactory;
        public PokemonService(IPokemonRepository pokemonRepository, SearchStrategyFactory searchStrategyFactory)
        {
            _pokemonRepository = pokemonRepository;
            _searchStrategyFactory = searchStrategyFactory;
        }

        public async Task<IEnumerable<PokemonListItemDto>> GetPokemonNamesListAsync(PokemonListRequest param)
        {
            var pokemonList = await _pokemonRepository.GetPokemonListAsync(param.Offset, param.Limit);
            if (pokemonList == null || !pokemonList.Any())
            {
                throw new PokemonNotFoundException($"with offset '{param.Offset}' and limit '{param.Limit}'");
            }
            //var pokemonListDto = pokemonList.Select(p => new PokemonListItemDto
            //{
            //    Name = p.PokemonName,
            //    Order = p.Order,
            //    //Abilities = string.Join(", ", p.PokemonAbilities),
            //    //Type = string.Join(", ", p.PokemonTypes)
            //});

            //var pokemonListDto = new List<PokemonListItemDto>();
            //foreach (var p in pokemonList)
            //{
            //    var pokemonDto = new PokemonListItemDto
            //    {
            //        Name = p.PokemonName,
            //    };
            //    if (p.NotFound.HasValue && p.NotFound==true) { 
            //        pokemonDto.NotFound = true;
            //    }
            //    else
            //    {
            //        pokemonDto.Order = p.Order;
            //    }
            //    pokemonListDto.Add(pokemonDto);
            //}
            var pokemonListDto = pokemonList.Select(p =>
            {
                if (p.NotFound.HasValue && p.NotFound == true)
                {
                    return new PokemonListItemDto
                    {
                        Name = p.PokemonName,
                        NotFound = true
                    };
                }
                else
                {

                }
                return new PokemonListItemDto
                {
                    Name = p.PokemonName,
                    Order = p.Order,

                };

            });
            return pokemonListDto;
        }

        //public IEnumerable<PokemonListItemDto> GetPokemonsAsync()
        //{

        //    var list = new List<PokemonListItemDto>
        //    {
        //        new PokemonListItemDto{

        //        Name="Bulbasaur",
        //        Order=1,
        //        Abilities="Overgrow, Chlorophyll",
        //        Type="Grass/Poison"
        //        }
        //     };
        //    return list;
        //}

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
