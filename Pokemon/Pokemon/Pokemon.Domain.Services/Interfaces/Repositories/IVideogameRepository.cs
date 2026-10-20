using PokemonApp.Domain.Models;

namespace PokemonApp.Domain.Services.Interfaces.Repositories
{
    public interface IVideogameRepository
    {
        List<Videogame> GetAll();
        Videogame? GetById(int id);
        void Add(Videogame videogame);
        void Delete(Videogame videogame);
    }
}
