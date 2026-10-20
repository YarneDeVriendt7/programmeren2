using Pokemon.Storage.DataModels;
using System.Collections.Generic;

namespace Pokemon.Domain.Services.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        List<PokemonDataModel> GetAll();
        PokemonDataModel? GetById(int id);
        void Add(PokemonDataModel pokemon);
        void Update(PokemonDataModel pokemon);
        void Delete(int id);
    }
}
