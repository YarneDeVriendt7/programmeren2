using PokemonApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Domain.Services.Interfaces.Repositories
{
    public interface IVideogameRepository
    {
        List<Videogame> GetAll();
        Videogame? GetById(int id);
        void Add(Videogame videogame);
        void Delete(Videogame videogame);
    }
}
