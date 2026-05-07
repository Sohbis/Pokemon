using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Models
{
    public sealed class PokemonSearchResponse
    {
        [JsonPropertyName("name")]
        public string PokemonName { get; set; } = string.Empty;

        [JsonPropertyName("sprites")]
        public PokemonSprite PokemonSprite { get; set; } = new();
    }

    public sealed class PokemonSprite
    {
        [JsonPropertyName("front_default")]
        public string Sprite { get; set; } = string.Empty;
    }


}
