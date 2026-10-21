using PokemonApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Api.Contracts.Pokemon
{
    public class PokemonRequestContract
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public PokemonType PokemonType { get; set; }
        public Rarity Rarity { get; set; }
    }
}
