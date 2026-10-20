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
        public ActionResult<VideogameResponseContract> CreateVideogame(
            [FromBody]VideogameRequestContract videogameRequest)
        {
            return Ok(_videogameService.CreateVideogame(videogameRequest));
        }
    }
}
