using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Common.Interfaces;
using Pokemon.Application.DTOs;
using Pokemon.Application.Models;


namespace Pokemon.Api.Controllers
{
    [ApiController]                      // ← Enables automatic model validation
    [Route("api/[controller]")]          // ← Route becomes: /api/pokemon
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("GetPokemonList", Name = "/GetPokemonList")]
        public  async Task<IActionResult> GetPokemonList([FromQuery] PokemonListRequest param)
        {
            var list = await _pokemonService.GetPokemonNamesListAsync(param);
            //if(list == null || !list.Any())
            //    return NotFound();
            return Ok(list);
        }

        //[HttpGet("GetPokemonByName/{name}", Name = "GetPokemonByName")] // ← Route becomes: /api/pokemon/name/{name}
        //public async Task<IActionResult> GetPokemonByName(string name)
        //{
        //    var pokemon = await _pokemonService.SearchPokemonByNameAsync(name);
        //    if (pokemon == null)
        //        return NotFound();
        //    return Ok(pokemon);
        //}
        //[HttpGet("GetPokemonById/{id:int}", Name = "GetPokemonById")] // ← Route becomes: /api/pokemon/id/{id} - Route Parameter, /api/pokemon? id = 1 - Query String
        //public async Task<IActionResult> GetPokemonById(int id)
        //{
        //    var pokemon = await _pokemonService.SearchPokemonByIdAsync(id);
        //    if (pokemon == null)
        //        return NotFound();
        //    return Ok(pokemon);
        //}

        // GET /api/pokemon/search?query=25
        // GET /api/pokemon/search?query=pikachu
        //[HttpGet("search", Name = "GetPokemonBySearch")]
        //public async Task<IActionResult> GetPokemonBySearch([FromQuery] string query)
        //{
        //    var pokemon = await _pokemonService.PokemonBySearchAsync(query);
        //    if (pokemon == null)
        //        return NotFound();
        //    return Ok(pokemon);
        //}

        [HttpPost("search", Name = "GetPokemonBySearch")]
        [ProducesResponseType(typeof(PokemonSearchDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPokemonBySearch([FromBody] PokemonSearchRequest searchRequest)
        {
            var pokemon = await _pokemonService.PokemonBySearchAsync(searchRequest);
            //if (pokemon == null)
            //    return NotFound();
            return Ok(pokemon);
        }


    }
}
