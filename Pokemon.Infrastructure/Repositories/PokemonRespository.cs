using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Exceptions;
using Pokemon.Domain.Interfaces;
using Pokemon.Infrastructure.Http;
using Pokemon.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokeApiHttpClient _pokeApiHttpClient;
        public PokemonRepository(PokeApiHttpClient pokeApiHttpClient)
        {
            _pokeApiHttpClient = pokeApiHttpClient;
        }
        public async Task<IEnumerable<PokemonList>> GetPokemonListAsync(int offset, int limit)
        {
            var pokemonList = await _pokeApiHttpClient.GetPokemonListAsync(offset, limit);
            if (pokemonList != null)
            {
                var tasks = new List<Task<PokemonDetails>>();

                foreach (var pokemon in pokemonList.PokemonNames)
                {
                    var name = pokemon.Name;
                    tasks.Add(GetPokemonBySearchAsync(pokemon.Name));
                }
                //var results = await Task.WhenAll(tasks) ?? Array.Empty<PokemonDetails>();

                var results = await Task.WhenAll(tasks);
                var pokemonListResult = new List<PokemonList>();
                for (var i = 0; i < results.Length; i++)
                {
                    if (results[i] != null)
                    {
                        pokemonListResult.Add(new PokemonList
                        {
                            PokemonName = results[i].PokemonName,
                            Order = results[i].Order,
                            //Abilities = p.Abilities,
                            //Type = p.Types,
                        });
                    }
                    else
                    {
                        pokemonListResult.Add(new PokemonList
                        {
                            PokemonName = pokemonList.PokemonNames[i].Name,
                            NotFound = true,
                            //Abilities = p.Abilities,
                            //Type = p.Types,
                        });
                    }
                }

                //var pokemonListResult = results.Select(p => new PokemonList
                //{
                //    PokemonName = p.PokemonName,
                //    Order = p.Order,
                //    //Abilities = p.Abilities,
                //    //Type = p.Types,
                //});
                //return pokemonListResult;
            }
            return Array.Empty<PokemonList>();
        }
        public async Task<PokemonDetails> GetPokemonBySearchAsync<T>(T searchCriteria)
        {
            var pokemonDetails = await _pokeApiHttpClient.GetPokemonBySearchAsync(searchCriteria);

            //if (pokemonDetails == null)
            //{
            //    throw new PokemonNotFoundException(searchCriteria.ToString());
            //}
            if (pokemonDetails != null)
            {
                var searchedPokemon = new PokemonDetails
                {
                    PokemonName = pokemonDetails.PokemonName,
                    PokemonSprites = pokemonDetails.PokemonSprite.Sprite,
                    Order = pokemonDetails.Order
                };
                return searchedPokemon;
            }

            return null;
        }

        //public Task<PokemonDetails> GetPokemonByNameAsync()
        //{
        //    throw new NotImplementedException();
        //}


    }
}
