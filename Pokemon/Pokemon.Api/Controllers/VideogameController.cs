using Microsoft.AspNetCore.Mvc;
using PokemonApp.Domain.Services.Interfaces.Services;
using PokemonApp.Api.Contracts.Videogame;

namespace PokemonApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideogameController(IVideogameService _videogameService) : ControllerBase
    {
        [HttpPost]
        public ActionResult<VideogameResponseContract> Create(
            [FromBody]VideogameRequestContract videogameRequest)
        {
            return Ok(_videogameService.Create(videogameRequest));
        }

        [HttpGet("{id}")]
        public ActionResult<VideogameResponseContract> GetById([FromRoute]int id)
        {
            var videogame = _videogameService.GetById(id);

            if(videogame is not null)
                return Ok(videogame);
            return NotFound();
        }

        [HttpGet()]
        public ActionResult<List<VideogameResponseContract>> GetAll()
        {
            return Ok(_videogameService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_videogameService.Delete(id))
                return NoContent();
            return BadRequest();
        }
    }
}
