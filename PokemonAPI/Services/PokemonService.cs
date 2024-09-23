using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PokemonAPI.Models;
using PokemonAPI.Services.Interface;
using System.Net.Http;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonModel> GetByName(string nome)
        {
            // Define a URL com o id ou nome do Pokémon
            string url = $"https://pokeapi.co/api/v2/pokemon/{nome}/";

            // Faz a requisição HTTP GET
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Verifica se a resposta foi bem-sucedida
            response.EnsureSuccessStatusCode();

            // Lê o conteúdo da resposta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Desserializa o JSON para um objeto do tipo PokemonModel
            PokemonModel pokemon = JsonConvert.DeserializeObject<PokemonModel>(responseBody);

            // Retorna o objeto PokemonModel
            return pokemon;
        }
    }
}
