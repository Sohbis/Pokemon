using Pokemon.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Exceptions
{
    public class PokemonNotFoundException : DomainException
    {
        
        public PokemonNotFoundException(string identifier) : base($"Pokémon {identifier} was not found.", DomainStatusCodes.NotFound)
        {

        }
    }
}
