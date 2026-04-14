using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Services.Exceptions;
using PokemonAPI.Services.Interface;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Busca Pokemon pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName([FromQuery] string nome)
        {
            try
            {
                var ret = await _pokemonService.GetByName(nome);
                return Ok(ret);
            }
            catch (PokemonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
