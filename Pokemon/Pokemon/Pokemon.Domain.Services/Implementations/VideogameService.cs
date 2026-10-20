using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Domain.Services.Interfaces.Services;
using PokemonApp.Api.Contracts.Videogame;
using PokemonApp.Domain.Services.Mapping;

namespace PokemonApp.Domain.Services.Implementations
{
    public class VideogameService(IVideogameRepository repository) : IVideogameService
    {
        public VideogameResponseContract CreateVideogame(VideogameRequestContract videogameRequest)
        {
            var videogameResponse = new VideogameResponseContract
            {
                Name = videogameRequest.Name,
            };

            repository.Add(videogameRequest.AsDomainModel());

            return videogameResponse;
        }
    }
}
