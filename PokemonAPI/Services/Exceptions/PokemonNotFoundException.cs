namespace PokemonAPI.Services.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException(string message) : base(message)
        {
        }
    }
}
