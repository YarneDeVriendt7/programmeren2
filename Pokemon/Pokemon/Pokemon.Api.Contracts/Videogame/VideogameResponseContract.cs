using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Api.Contracts.Videogame
{
    public class VideogameResponseContract
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
    }
}
