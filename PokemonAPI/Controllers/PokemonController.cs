using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.Services.Interface;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService PokemonService)
        {
            _pokemonService = PokemonService;
        }

        /// <summary>
        /// Busca Pokemon pelo nome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>    


        // TODO: Implementar método GetByName

        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName([FromQuery]string nome)
        {
            var ret = await _pokemonService.GetByName(nome);
            return Ok(ret);
        }

    }
}
