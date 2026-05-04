using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.ValueObjects
{
    public class PokemonType
    {
        public string Type { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class PokemonTypes
    {
        public int Slot { get; set; }
        public PokemonType Types { get; set; } = new PokemonType();
    }
}
