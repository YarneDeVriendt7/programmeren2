using PokemonApp.Api.Contracts.Videogame;
using PokemonApp.Domain.Models;
using System.Linq;

namespace PokemonApp.Domain.Services.Mapping
{
    public static class VideogameMappingExtensions
    {
        public static Videogame AsDomainModel(this VideogameRequestContract req)
        {
            return new Videogame
            {
                Name = req.Name,
                Pokemons = req.PokemonIds.Select(id => new Pokemon { Id = id }).ToList(),
            };
        }
    }
}
