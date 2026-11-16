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
                System.Console.Write("Vrednost nije validna. Pokusajte ponovo: ");

                input = System.Console.ReadLine() ?? string.Empty;
            }

            return input;
        }

        public static string SafeInputStr(string ispis)
        {
            Console.Write(ispis);
            return SafeInputStr();
        }

        public static int SafeInputInt(string ispis)
        {
            Console.Write(ispis);
            return SafeInputInt();
        }

        public static DateOnly SafeInputDateOnly(string ispis)
        {
            string input = SafeInputStr(ispis);
            while(!DateOnly.TryParseExact(input,"yyyy-MM-dd", out DateOnly date))
            {
                Console.WriteLine("Greska! Nije dobar format datuma!");
            }
         
            return DateOnly.ParseExact(input, "yyyy-MM-dd");
        }

        public static DateOnly SafeInputDateOnly()
        {
            string input = SafeInputStr();
            while (!DateOnly.TryParseExact(input, "yyyy-MM-dd", out DateOnly date))
            {
                Console.WriteLine("Greska! Nije dobar format datuma!");
            }

            return DateOnly.ParseExact(input, "yyyy-MM-dd");
        }
    }
}
