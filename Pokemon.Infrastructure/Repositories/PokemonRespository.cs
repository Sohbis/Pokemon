using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Exceptions;
using Pokemon.Domain.Interfaces;
using Pokemon.Domain.ValueObjects;
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
                            Abilities = results[i].Abilities,
                            Types = results[i].Types,
                        });
                    }
                    else
                    {
                        pokemonListResult.Add(new PokemonList
                        {
                            PokemonName = pokemonList.PokemonNames[i].Name,
                            NotFound = true,

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
                //var temp = pokemonDetails.Types;

                //foreach (var type in temp)
                //{
                //    var typeName = type.Slot;
                //    var typeValue = type.PType;
                //}
                //var temp2 = temp.Select(t =>
                //{
                //  var obj = new
                //  {
                //        Slot = t.Slot,
                //        PType = t.PType,
                //  };
                //    return obj;

                //});
                var searchedPokemon = new PokemonDetails
                {
                    PokemonName = pokemonDetails.PokemonName,
                    PokemonSprites = pokemonDetails.PokemonSprite.Sprite,
                    Order = pokemonDetails.Order,
                    Abilities = pokemonDetails.Abilities.Select(t=> new Domain.ValueObjects.PokemonAbilities
                    {
                        Slot= t.AbilitySlot,
                        IsHidden = t.IsAbilityHidden,
                        Ability = new Domain.ValueObjects.PokemonAbility
                        {
                            AbilityName = t.Ability.AbilityName,
                            Url = t.Ability.Url
                        }

                    }).ToArray(),

                    Types = pokemonDetails.Types.Select(t => new Domain.ValueObjects.Types
                    {
                        Slot = t.Slot,
                        // Assuming your Domain Type also has Name/Url or similar
                        Type = new Domain.ValueObjects.Type
                        {
                            Name = t.PType.Name,
                            Url = t.PType.Url
                        }
                    }).ToArray()

                };

                return searchedPokemon;

                //var pokemonListResult = new PokemonDetails();

                //pokemonListResult.PokemonName = pokemonDetails.PokemonName;
                //pokemonListResult.Order = pokemonDetails.Order;
                //pokemonListResult.PokemonSprites = pokemonDetails.PokemonSprite.Sprite;

                //var pokemonListResult1 = new PokemonDetails
                //{
                //    Types = new List<Types> {
                //        new Types { Slot = 1 }, new Types { Slot = 2 }
                //    }
                //};

                ////pokemonListResult1.Types = new List<Types> { new Types { Slot = 1 }, new Types { Slot = 2 } };


                //for (var i = 0; i < pokemonDetails.Types.Count; i++)
                //{
                //    pokemonListResult.Types[i].Slot = pokemonDetails.Types[i].Slot;
                //    pokemonListResult.Types[i].Type.Name = pokemonDetails.Types[i].PType.Name;
                //    pokemonListResult.Types[i].Type.Url = pokemonDetails.Types[i].PType.Url;
                //}

                //return pokemonListResult;
            }

            return null;
        }

        //public Task<PokemonDetails> GetPokemonByNameAsync()
        //{
        //    throw new NotImplementedException();
        //}


    }
}
