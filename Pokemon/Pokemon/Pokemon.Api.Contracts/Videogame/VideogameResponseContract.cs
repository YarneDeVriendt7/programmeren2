using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Api.Contracts.Videogame
{
    public class VideogameResponseContract
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime DatumUitgave { get; set; }
    }
}
