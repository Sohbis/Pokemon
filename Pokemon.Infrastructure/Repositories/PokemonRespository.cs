using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Exceptions;
using Pokemon.Domain.Interfaces;
using Pokemon.Infrastructure.Http;
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
                var pokemonListResult = pokemonList.Select(p => new PokemonList
                {
                    Name = p.PokemonName,
                    Order = p.Order,
                    //Abilities = p.Abilities,
                    //Type = p.Types,
                });
                return pokemonListResult;
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
