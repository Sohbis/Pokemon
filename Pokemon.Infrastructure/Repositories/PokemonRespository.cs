using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Interfaces;
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
        public Task<IEnumerable<PokemonList>> GetPokemonListAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<PokemonDetails> GetPokemonBySearchAsync<T>(T searchCriteria)
        {
            var pokemonDetails = await _pokeApiHttpClient.GetPokemonBySearchAsync(searchCriteria);

            if (pokemonDetails == null)
            {
                throw new ArgumentException("No Pokemon found with the given search criteria."); ;
            }

            var searchedPokemon = new PokemonDetails
            {
                PokemonName = pokemonDetails.PokemonName,
                PokemonSprites = pokemonDetails.PokemonSprite.Sprite,
            };
            return searchedPokemon;
        }

        public Task<PokemonDetails> GetPokemonByNameAsync()
        {
            throw new NotImplementedException();
        }


    }
}
