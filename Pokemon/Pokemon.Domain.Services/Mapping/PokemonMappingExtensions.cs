using PokemonApp.Api.Contracts.Pokemon;
using PokemonApp.Domain.Models;
using PokemonApp.Storage.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Domain.Services.Mapping
{
    public static class PokemonMappingExtensions
    {
        public static Pokemon AsDomainModel(this PokemonRequestContract req)
        {
            return new Pokemon
            {
                Name = req.Name,
                PokemonType = req.PokemonType,
                Rarity = req.Rarity,
            };
        }

        public static Pokemon AsDomainModel(this PokemonDataModel dataModel)
        {
            return new Pokemon
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                PokemonType = dataModel.PokemonType,
                Rarity = dataModel.Rarity,
            };
        }

        public static PokemonDataModel AsDataModel(this Pokemon pokemon)
        {
            return new PokemonDataModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                PokemonType = pokemon.PokemonType,
                Rarity = pokemon.Rarity,
            };
        }

        public static PokemonResponseContract AsContract(this Pokemon pokemon)
        {
            return new PokemonResponseContract
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                PokemonType = pokemon.PokemonType,
                Rarity = pokemon.Rarity,
            };
        }
    }
}
