using Pokemon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.ValueObjects
{

    sealed public class Type
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    sealed public class Types
    {
        public int Slot { get; set; }
        public Type Type { get; set; } = new Type();
    }

    //sealed public class PokemonTypes
    //{
    //    public IReadOnlyList<Types> Types { get; set; } = new List<Types>();
    //}
}