using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PokemonAPI.Services;

namespace PokemonAPI.Tests.Services;

public class PokemonServiceTests
{
    [Fact]
    public async Task GetByName_WhenPokemonIsPikachu_ReturnsExpectedFields()
    {
        const string responseJson = """
        {
          "id": 25,
          "name": "pikachu",
          "base_experience": 112,
          "height": 4,
          "is_default": true,
          "order": 35,
          "weight": 60
        }
        """;

        var handler = new StubHttpMessageHandler(responseJson);
        var httpClient = new HttpClient(handler);
        var service = new PokemonService(httpClient);

        var result = await service.GetByName("pikachu");

        Assert.Equal("https://pokeapi.co/api/v2/pokemon/pikachu/", handler.LastRequestUri);
        Assert.NotNull(result);
        Assert.Equal(25, result.Id);
        Assert.Equal("pikachu", result.Name);
        Assert.Equal(112, result.BaseExperience);
        Assert.Equal(4, result.Height);
        Assert.True(result.IsDefault);
        Assert.Equal(35, result.Order);
        Assert.Equal(60, result.Weight);
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _responseJson;

        public StubHttpMessageHandler(string responseJson)
        {
            _responseJson = responseJson;
        }

        public string? LastRequestUri { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            LastRequestUri = request.RequestUri?.ToString();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_responseJson)
            };

            return Task.FromResult(response);
        }
    }
}
