using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Api.Contracts.Videogame
{
    public class VideogameResponseContract
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime DatumUitgave { get; set; }
    }
}
