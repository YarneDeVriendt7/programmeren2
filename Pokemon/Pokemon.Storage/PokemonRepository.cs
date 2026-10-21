using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Storage.Repos
{
    public class PokemonRepository : IPokemonRepository
    {
        public void Add(PokemonDataModel pokemon)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PokemonDataModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PokemonDataModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PokemonDataModel pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
