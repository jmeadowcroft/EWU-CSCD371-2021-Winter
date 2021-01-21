using System;

namespace CanHazFunny
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string line)
            => Console.WriteLine(line);
    }
}