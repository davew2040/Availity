using LispParenthesesCheckerLibrary;
using System;

namespace LispParenthesesCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPrompt();

            string input;
            while ((input = Console.ReadLine()).ToLower() != "quit")
            {
                var validateResult = LispParentheseChecker.Validate(input);

                var prettyResult = validateResult ? "passed" : "failed";

                Console.WriteLine($"Validation {prettyResult}.\n");

                PrintPrompt();
            }

            PrintDone();
        }

        private static void PrintPrompt()
        {
            Console.Write("Test Input> ");
        }


        private static void PrintDone()
        {
            Console.Write("Exiting!");
        }
    }
}
