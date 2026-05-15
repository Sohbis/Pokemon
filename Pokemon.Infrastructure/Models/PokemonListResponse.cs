using Pokemon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Models
{
    public class PokemonListResponse
    {
        //[JsonPropertyName("name")]
        //public string PokemonName { get; init; } = string.Empty;
        [JsonPropertyName("order")]
        public int Order { get; init; }
        [JsonPropertyName("abilities")]
        public IReadOnlyList<PokemonAbilities> Abilities { get; init; } = new List<PokemonAbilities>();
        [JsonPropertyName("types")]
        public IReadOnlyList<PokemonTypes> Types { get; init; } = new List<PokemonTypes>();
    }

    public sealed class PokemonAbilities
    {
        [JsonPropertyName("slot")]
        public int AbilitySlot { get; init; }
        [JsonPropertyName("isHidden")]
        public bool IsAbilityHidden { get; init; }

        [JsonPropertyName("ability")]
        public PokemonAbility Ability { get; init; } = new PokemonAbility();
    }


    public sealed class PokemonAbility
    {
        [JsonPropertyName("name")]
        public string AbilityName { get; init; }= string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; init; }= string.Empty;

    }


    public sealed class PokemonType
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; init; } = string.Empty;
    }

    public sealed class PokemonTypes
    {
        [JsonPropertyName("slot")]
        public int Slot { get; init; }
        [JsonPropertyName("type")]
        public PokemonType PType { get; init; } = new();
    }



    public sealed class PokemonNamesListResponse
    {
        [JsonPropertyName("results")]
        public IReadOnlyList<PokemonName> PokemonNames { get; init; }

    }

    public class PokemonName
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

    }


}
