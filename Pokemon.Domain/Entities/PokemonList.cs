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
        public int? Order { get; set; }
        public bool? NotFound { get; set; }
        public IReadOnlyList<PokemonAbilities> Abilities { get; set; } = new List<PokemonAbilities>();

        //public IReadOnlyList<Types> Types { get; set; } = new List<Types>();

        //public IList<Types> Types { get; set; } = new List<Types>();

        public IReadOnlyList<Types> Types { get; init; } = new List<Types>();
    }
}
