using Pokemon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Entities
{
    public class PokemonList
    {
        public string PokemonName { get; set; } = string.Empty;
        public int Order { get; set; }
        //public PokemonAbilities Abilities { get; set; } = new PokemonAbilities();
        //public PokemonTypes Type { get; set; } = new PokemonTypes();
    }
}
