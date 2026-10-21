using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PokemonApp.Api.Contracts.Videogame
{
    public class VideogameRequestContract
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public List<int> PokemonIds { get; set; } = new();
    }
}
