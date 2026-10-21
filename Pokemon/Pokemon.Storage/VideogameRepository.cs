using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Domain.Models;
using PokemonApp.Storage.DataModels;

namespace PokemonApp.Storage.Repos
{
    public class VideogameRepository : IVideogameRepository
    {
        private readonly Dictionary<int, VideogameDataModel> _videogames = new();

        public VideogameDataModel Create(VideogameDataModel videogame)
        {
            var id = 1;      

            if(_videogames.Keys.Count > 0) 
                id = _videogames.Keys.Max() + 1;

            videogame.Id = id;
            _videogames[id] = videogame;

            return _videogames[id];
        }

        public VideogameDataModel? GetById(int id)
        {
            return _videogames.GetValueOrDefault(id);
        }

        public List<VideogameDataModel> GetAll()
        {
            return _videogames.Values.ToList();
        }

        public bool DeleteById(int id)
        {
            return _videogames.Remove(id);
        }
    }
}
