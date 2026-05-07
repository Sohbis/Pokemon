using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Models
{
    sealed public class PokemonListRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "Offset can't be negative")] 
        public int Offset { get; init; }

        [Range(1, 10, ErrorMessage = "Limit must be between 1 and 10.")]
        public int Limit { get; init; }

    }
}
