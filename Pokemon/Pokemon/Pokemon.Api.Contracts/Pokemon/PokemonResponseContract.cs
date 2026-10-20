using PokemonApp.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Api.Contracts.Pokemon
{
    public class PokemonResponseContract
    {
        public string Name { get; set; } = string.Empty;
        public PokemonType Type { get; set; }
        public Rarity Rarity { get; set; }
    }
}
