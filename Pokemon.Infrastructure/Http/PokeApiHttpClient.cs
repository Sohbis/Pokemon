using Pokemon.Domain.Entities;
using Pokemon.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Http
{
    public class PokeApiHttpClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PokemonListResponse>?> GetPokemonListAsync(int offset, int limit)
        {
            var response = await _httpClient.GetAsync($"pokemon/?offset={offset}&limit={limit}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            //var temp = await response.Content.ReadAsStringAsync();

            //PokemonNameListResponse pokemonNameList = JsonSerializer.Deserialize<PokemonNameListResponse>(temp)??new PokemonNameListResponse();

            // var tasks  = new List<Task<PokemonListResponse?>>();

            //foreach (var pokemon in pokemonNameList.PokemonNames)
            //    tasks.Add(GetPokemonListAsync(pokemon.Name));


            var content = await response.Content.ReadFromJsonAsync<PokemonNameListResponse>();

            var tasks = new List<Task<PokemonListResponse?>>();

            foreach (var pokemon in content.PokemonNames)
                tasks.Add(GetPokemonListAsync(pokemon.Name));

            PokemonListResponse[] results = await Task.WhenAll(tasks) ?? Array.Empty<PokemonListResponse>();

            return results;
        }

        private async Task<PokemonListResponse?> GetPokemonListAsync(string pokemonName)
        {
            var response = await _httpClient.GetAsync($"pokemon/{pokemonName}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            //var temp = await response.Content.ReadAsStringAsync();

            return await response.Content.ReadFromJsonAsync<PokemonListResponse>();
        }

        public async Task<PokemonSearchResponse?> GetPokemonBySearchAsync<T>(T param)
        {
            var response = await _httpClient.GetAsync($"pokemon/{param}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var temp = await response.Content.ReadAsStringAsync();


            return await response.Content.ReadFromJsonAsync<PokemonSearchResponse>();
        }
    }
}
