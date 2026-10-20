using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PokemonApp.Api.Contracts.Videogame
{
    public class VideogameRequestContract
    {
        [MaxLength(50)]
        public string Naam { get; set; }
        [MaxLength(300)]
        public string Beschrijving { get; set; }
        [Required]
        public DateTime DatumUitgave { get; set; }
    }
}
