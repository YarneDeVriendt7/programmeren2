using PokemonApp.Domain.Models.Enums;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Domain.Services.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        PokemonDataModel Create(PokemonDataModel pokemon);
        List<PokemonDataModel> GetAll();
        PokemonDataModel? GetById(int id);
        List<PokemonDataModel> GetByType(PokemonType type);
        bool DeleteById(int id);

    }
}
