using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                PrintUsage();
                Environment.Exit(1);
            }
            var result = new rover_lib.Rover().go(args[0]);
            Console.WriteLine($"{result}");
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage : <Program> [Sequence of L,R, or M]");
        }
    }
}
