using PokemonApp.Domain.Models;
using PokemonApp.Domain.Models.Enums;
using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Storage.Repos
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly Dictionary<int, PokemonDataModel> _pokemons = new();

        public PokemonDataModel Create(PokemonDataModel pokemon)
        {
            var id = 1;

            if (_pokemons.Keys.Count > 0)
                id = _pokemons.Keys.Max() + 1;

            pokemon.Id = id;
            _pokemons[id] = pokemon;

            return _pokemons[id];
        }

        public PokemonDataModel? GetById(int id)
        {
            return _pokemons.GetValueOrDefault(id);
        }

        public List<PokemonDataModel> GetAll()
        {
            return _pokemons.Values.ToList();
        }

        public List<PokemonDataModel> GetByType(PokemonType type)
        {
            return _pokemons
                .Where(p => p.Value.PokemonType == type)
                .Select(p => p.Value)
                .ToList();
        }

        public bool DeleteById(int id)
        {
            return _pokemons.Remove(id);
        }
    }
}
