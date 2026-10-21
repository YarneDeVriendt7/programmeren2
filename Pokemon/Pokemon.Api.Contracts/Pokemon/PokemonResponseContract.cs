using PokemonApp.Domain.Models.Enums;
namespace PokemonApp.Api.Contracts.Pokemon
{
    public class PokemonResponseContract
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonType Type { get; set; }
        public Rarity Rarity { get; set; }
    }
}
