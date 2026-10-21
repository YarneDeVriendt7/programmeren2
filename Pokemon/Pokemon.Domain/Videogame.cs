using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Domain.Models
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Pokemon> Pokemons { get; set; } = new();
    }
}
