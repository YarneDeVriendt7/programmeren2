using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Storage.DataModels
{
    public class VideogameDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> PokemonIds { get; set; } = new();
    }
}
