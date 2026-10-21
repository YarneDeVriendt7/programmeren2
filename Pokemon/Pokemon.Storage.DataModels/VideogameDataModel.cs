using System.Collections.Generic;

namespace PokemonApp.Storage.DataModels
{
    public class VideogameDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> PokemonIds { get; set; } = new();
    }
}
