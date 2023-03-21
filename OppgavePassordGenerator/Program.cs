using System;

namespace OppgavePassordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                MyConsole.ShowInputInstructions();
            }
        }
    }
}
