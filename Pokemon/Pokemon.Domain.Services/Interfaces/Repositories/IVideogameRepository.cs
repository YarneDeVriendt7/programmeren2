using PokemonApp.Domain.Models;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Domain.Services.Interfaces.Repositories
{
    public interface IVideogameRepository
    {
        VideogameDataModel Create(VideogameDataModel videogame);
        List<VideogameDataModel> GetAll();
        VideogameDataModel? GetById(int id);
        VideogameDataModel Update(VideogameDataModel videogame);
        bool DeleteById(int id);
    }
}
