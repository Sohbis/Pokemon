using Pokemon.Domain.Entities;
using Pokemon.Infrastructure.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure
{
    public class PokeApiHttpClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonSearchResponse?> GetPokemonBySearchAsync<T>(T param)
        {
            var response = await _httpClient.GetAsync($"pokemon/{param}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
                
            return  await response.Content.ReadFromJsonAsync<PokemonSearchResponse>();
        }
    }
}
