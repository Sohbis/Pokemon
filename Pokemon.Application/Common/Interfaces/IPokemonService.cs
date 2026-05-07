//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Pokemon.Application.DTOs;
using Pokemon.Application.Models;
using Pokemon.Domain.Enums;

namespace Pokemon.Application.Common.Interfaces
{
    public interface IPokemonService
    {
        //IEnumerable<PokemonListItemDto> GetPokemonsAsync();
        //Task<PokemonSearchDto> PokemonBySearchAsync<T>(T searchCriteria);
        Task<IEnumerable<PokemonListItemDto>> GetPokemonsListAsync(PokemonListRequest param);
        Task<PokemonSearchDto> PokemonBySearchAsync(PokemonSearchRequest searchCriteria);
    }
}
