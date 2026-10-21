using PokemonApp.Domain.Models;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Domain.Services.Interfaces.Repositories
{
    public interface IVideogameRepository
    {
        VideogameDataModel Create(VideogameDataModel videogame);
        List<VideogameDataModel> GetAll();
        VideogameDataModel? GetById(int id);
        void Add(VideogameDataModel videogame);
        void Delete(VideogameDataModel videogame);
    }
}
