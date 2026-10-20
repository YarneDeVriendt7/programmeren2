using System.Collections.Generic;
using PokemonApp.Api.Contracts.Pokemon;

namespace PokemonApp.Api.Contracts.Videogame
{
    public class VideogameResponseContract
    {
        public List<PokemonResponseContract> Pokemons { get; set; } = new();
        public string Name { get; set; } = string.Empty;
    }
}
