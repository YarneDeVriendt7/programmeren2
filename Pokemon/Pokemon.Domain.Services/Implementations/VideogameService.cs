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
        public VideogameResponseContract CreateVideogame(VideogameRequestContract videogameRequest)
        {
            Videogame videogame = videogameRequest.AsDomainModel();

            bool exists = repository.GetAll()
                .Any(v => v.Name.Equals(
                    videogame.Name,
                    StringComparison.OrdinalIgnoreCase));

            if (exists)           
                throw new ArgumentException("Videogame with this name already exists.");
            
            VideogameDataModel createdVideogame = repository.Create(videogame.AsDataModel());

            return createdVideogame.AsDomainModel().AsContract();
        }
    }
}
