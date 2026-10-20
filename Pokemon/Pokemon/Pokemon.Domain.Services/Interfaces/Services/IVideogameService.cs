using PokemonApp.Api.Contracts.Videogame;

namespace PokemonApp.Domain.Services.Interfaces.Services
{
    public interface IVideogameService
    {
        VideogameResponseContract CreateVideogame(VideogameRequestContract videogameRequest);
    }
}
