using System.Net.Http;
using System.Net.Http.Json;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            JokeResponse joke = HttpClient.GetFromJsonAsync<JokeResponse>("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            return joke.Joke;
        }

        private record JokeResponse(string Joke) { }
    }
}
