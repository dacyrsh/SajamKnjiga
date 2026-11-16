using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    // bazirano na Vezbama 3!
    // provera unosa 
    static class ConsoleViewUtils
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
    }
}
