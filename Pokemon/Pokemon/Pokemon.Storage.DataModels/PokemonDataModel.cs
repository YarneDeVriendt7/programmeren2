using PokemonApp.Domain.Models.Enums;

namespace PokemonApp.Storage.DataModels
{
    public class PokemonDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonType Type { get; set; }
        public Rarity Rarity { get; set; }
    }
}
