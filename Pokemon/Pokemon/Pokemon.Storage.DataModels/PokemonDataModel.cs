using PokemonApp.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Storage.DataModels
{
    public class PokemonDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonType Type { get; set; }
        public Rarity Rarity { get; set; }
    }
}
