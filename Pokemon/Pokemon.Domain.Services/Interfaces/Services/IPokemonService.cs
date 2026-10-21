using PokemonApp.Api.Contracts.Pokemon;
using PokemonApp.Domain.Models.Enums;

namespace PokemonApp.Domain.Services.Interfaces.Services
{
    public interface IPokemonService
    {
        PokemonResponseContract Create(PokemonRequestContract videogameRequest);
        PokemonResponseContract GetById(int id);
        List<PokemonResponseContract> GetByType(PokemonType type);
        List<PokemonResponseContract> GetAll();
        bool Delete(int id);
    }
}
