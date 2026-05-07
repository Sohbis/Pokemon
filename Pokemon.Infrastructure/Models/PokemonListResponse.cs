using Pokemon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Models
{
    public sealed class PokemonListResponse
    {
        [JsonPropertyName("name")]
        public string PokemonName { get; set; } = string.Empty;
        [JsonPropertyName("order")]
        public int Order { get; set; }
        //[JsonPropertyName("abilities")]
        //public PokemonAbilities Abilities { get; set; } = new PokemonAbilities();
        //[JsonPropertyName("types")]
        //public PokemonTypes Types { get; set; } = new PokemonTypes();
    }

    public sealed class PokemonNameListResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<PokemonName> PokemonNames { get; init; } = Enumerable.Empty<PokemonName>();

    }

    public sealed class PokemonName
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

    }


}
