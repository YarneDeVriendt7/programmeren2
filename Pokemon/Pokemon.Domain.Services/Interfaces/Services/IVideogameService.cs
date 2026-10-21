using PokemonApp.Api.Contracts.Videogame;

namespace PokemonApp.Domain.Services.Interfaces.Services
{
    public interface IVideogameService
    {
        VideogameResponseContract Create(VideogameRequestContract videogameRequest);
        VideogameResponseContract GetById(int id);
        List<VideogameResponseContract> GetAll();
        bool Delete(int id);
    }
}
