using Microsoft.AspNetCore.Mvc;
using PokemonApp.Api.Contracts.Pokemon;
using PokemonApp.Api.Contracts.Videogame;
using PokemonApp.Domain.Models.Enums;
using PokemonApp.Domain.Services.Implementations;
using PokemonApp.Domain.Services.Interfaces.Services;

namespace PokemonApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController(IPokemonService _pokemonService) : ControllerBase
    {
        [HttpPost]
        public ActionResult<PokemonResponseContract> Create(
            [FromBody] PokemonRequestContract pokemonRequest)
        {
            return Ok(_pokemonService.Create(pokemonRequest));
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonResponseContract> GetById([FromRoute] int id)
        {
            var pokemon = _pokemonService.GetById(id);

            if (pokemon is not null)
                return Ok(pokemon);
            return NotFound();
        }

        [HttpGet()]
        public ActionResult<List<PokemonResponseContract>> GetAll()
        {
            return Ok(_pokemonService.GetAll());
        }

        [HttpGet("type/{type}")]
        public ActionResult<List<PokemonResponseContract>> GetByType(
            [FromRoute] PokemonType type)
        {
            var pokemons = _pokemonService.GetByType(type);

            if (pokemons.Any())
                return Ok(pokemons);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_pokemonService.Delete(id))
                return NoContent();
            return BadRequest();
        }
    }
}
