using System;

namespace CanHazFunny
{
    public class Jester
    {
        public Jester(IOutput output, IJokeService jokeService)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }

        private IOutput Output { get; }
        private IJokeService JokeService { get; }

        public void TellJoke()
        {
            string joke;
            do
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));
            Output.WriteLine(joke);
        }
    }
}
