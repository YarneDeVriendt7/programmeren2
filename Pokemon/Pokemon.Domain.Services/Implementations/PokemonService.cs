using PokemonApp.Api.Contracts.Pokemon;
using PokemonApp.Domain.Models;
using PokemonApp.Domain.Models.Enums;
using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Domain.Services.Interfaces.Services;
using PokemonApp.Domain.Services.Mapping;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Domain.Services.Implementations
{
    public class PokemonService(IPokemonRepository repository) : IPokemonService
    {
        public PokemonResponseContract Create(PokemonRequestContract pokemonRequest)
        {
            Pokemon pokemon = pokemonRequest.AsDomainModel();

            bool exists = repository.GetAll()
                .Any(p => p.Name
                .Equals(pokemon.Name, StringComparison.OrdinalIgnoreCase));

            if (exists)
                throw new ArgumentException("Pokemon with this name already exists.");

            PokemonDataModel createdPokemon = repository.Create(pokemon.AsDataModel());

            return createdPokemon.AsDomainModel().AsContract();
        }

        public bool Delete(int id)
        {
            return repository.DeleteById(id);
        }

        public List<PokemonResponseContract> GetAll()
        {
            var pokemons = repository.GetAll().
                Select(p => p.AsDomainModel()) ?? throw new ArgumentNullException("No pokemon found.");

            return pokemons.Select(p => p.AsContract()).ToList();
        }

        public PokemonResponseContract GetById(int id)
        {
            var pokemon = repository.GetById(id)?.AsDomainModel() 
                ?? throw new ArgumentNullException($"Pokemon with id= {id} not found.");
            return pokemon.AsContract();
        }

        public List<PokemonResponseContract> GetByType(PokemonType type)
        {
            var pokemons = repository.GetByType(type).
                Select(p => p.AsDomainModel()) ?? throw new ArgumentNullException($"No {type}-type pokemon found.");

            return pokemons.Select(p => p.AsContract()).ToList();
        }
    }
}
