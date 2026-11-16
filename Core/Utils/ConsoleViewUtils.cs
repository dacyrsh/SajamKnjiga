using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    // bazirano na Vezbama 3!
    // provera unosa 
    public static class ConsoleViewUtils
    {   
        public static int SafeInputInt()
        {
            int input;

            string rawInput = System.Console.ReadLine() ?? string.Empty; 

            while(!int.TryParse(rawInput, out input))
            {
                System.Console.WriteLine("Broj nije validan. Pokusajte ponovo: ");

                rawInput = System.Console.ReadLine() ?? string.Empty;
            }

            return input;
        }

        public static string SafeInputStr()
        {
            string input = System.Console.ReadLine() ?? string.Empty;

            while(string.IsNullOrEmpty(input))
            {
                System.Console.WriteLine("Vrednost nije validna. Pokusajte ponovo: ");

                input = System.Console.ReadLine() ?? string.Empty;
            }

            return input;
        }
    }
}
