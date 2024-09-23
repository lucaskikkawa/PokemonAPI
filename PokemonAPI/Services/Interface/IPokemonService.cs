
using PokemonAPI.Models;

namespace PokemonAPI.Services.Interface
{
    public interface IPokemonService
    {
        Task<PokemonModel> GetByName(string nome);
    }
}
