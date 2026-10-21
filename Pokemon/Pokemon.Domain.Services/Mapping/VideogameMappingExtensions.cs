using PokemonApp.Api.Contracts.Pokemon;
using PokemonApp.Api.Contracts.Videogame;
using PokemonApp.Domain.Models;
using PokemonApp.Storage.DataModels;
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
                Pokemons = req.PokemonIds
                    .Select(id => new Pokemon { Id = id })
                    .ToList(),
            };
        }

        public static Videogame AsDomainModel(this VideogameDataModel dataModel)
        {
            return new Videogame
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                Pokemons = dataModel.PokemonIds
                    .Select(id => new Pokemon { Id = id })
                    .ToList()
            };
        }

        public static VideogameDataModel AsDataModel(this Videogame videogame)
        {
            return new VideogameDataModel
            {
                Id = videogame.Id,
                Name = videogame.Name,
                PokemonIds = videogame.Pokemons
                    .Select(p => p.Id)
                    .ToList()
            };
        }

        public static VideogameResponseContract AsContract(this Videogame videogame)
        {
            return new VideogameResponseContract
            {
                Name = videogame.Name,
                Pokemons = videogame.Pokemons
                    .Select(p => new PokemonResponseContract
                    {
                        Id = p.Id,
                        Name = p.Name,
                        PokemonType = p.PokemonType,
                        Rarity = p.Rarity
                    })
                    .ToList()
            };
        }
    }
}
