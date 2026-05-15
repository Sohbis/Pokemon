using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.ValueObjects
{
    public sealed class PokemonAbility
    {
        public string AbilityName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
    public sealed class PokemonAbilities
    {
        public PokemonAbility Ability { get; set; } = new PokemonAbility();
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}
