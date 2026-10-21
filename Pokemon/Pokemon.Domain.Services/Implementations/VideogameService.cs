using PokemonApp.Api.Contracts.Videogame;
using PokemonApp.Domain.Models;
using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Domain.Services.Interfaces.Services;
using PokemonApp.Domain.Services.Mapping;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Domain.Services.Implementations
{
    public class VideogameService(IVideogameRepository repository) : IVideogameService
    {
        public VideogameResponseContract Create(VideogameRequestContract videogameRequest)
        {
            Videogame videogame = videogameRequest.AsDomainModel();

            bool exists = repository.GetAll()
                .Any(v => v.Name
                .Equals(videogame.Name, StringComparison.OrdinalIgnoreCase));

            if (exists)           
                throw new ArgumentException("Videogame with this name already exists.");
            
            VideogameDataModel createdVideogame = repository.Create(videogame.AsDataModel());

            return createdVideogame.AsDomainModel().AsContract();
        }

        public bool Delete(int id)
        {
            return repository.DeleteById(id);
        }

        public List<VideogameResponseContract> GetAll()
        {
            var videogames = repository.GetAll().
                Select(v => v.AsDomainModel()) ?? throw new ArgumentNullException("No videogames found.");

            return videogames.Select(v => v.AsContract()).ToList();
        }

        public VideogameResponseContract GetById(int id)
        {
            var videogame = repository.GetById(id)?.AsDomainModel() ?? throw new ArgumentNullException($"Videogame with id= {id} not found.");
            return videogame.AsContract();
        }
    }
}
