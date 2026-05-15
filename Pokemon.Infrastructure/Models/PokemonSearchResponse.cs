using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Models
{
    public sealed class PokemonSearchResponse : PokemonListResponse
    {
        [JsonPropertyName("name")]
        public string PokemonName { get; init; } = string.Empty;

        [JsonPropertyName("sprites")]
        public PokemonSprite PokemonSprite { get; init; } = new();
    }

    public sealed class PokemonSprite
    {
        [JsonPropertyName("front_default")]
        public string Sprite { get; init; } = string.Empty;
    }


}
