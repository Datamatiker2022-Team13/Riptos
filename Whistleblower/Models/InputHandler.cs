using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Whistleblower.Models
{
    public class InputHandler
    {
        public static string GetUserInputString(string prompt) // bliver userinput sendt fra en anden klasse eller beder denne klasse om userinput?
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }
                Console.WriteLine("Dummy du skal bruge bogstaver");
            }
        }
        public static int GetUserInputInt(string prompt)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Dummy. du skal bruge tal");
            }
        }
        public static int GetUserInputInt(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    if (result >= minValue && result <= maxValue)
                        return result;

                }
                else
                {
                    Console.WriteLine($"Dummy. Dit tal skal være inden for {0}-{1}", minValue, maxValue);
                }
            }
        }
        public static bool GetUserInputBool(string prompt)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (bool.TryParse(input, out bool result))
                {
                    return result;
                }
                Console.WriteLine("Dummy. skriv True/False");
            }
        }
    }
}
