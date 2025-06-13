using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal static class UIService
    {
        public static int GetValidInteger(string prompt)
        {
            int validationOutput = 0;
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(userInput, out validationOutput))
                {
                    return validationOutput;
                }
                else
                {
                    Console.WriteLine("You did not put in a valid number, try again");
                }
            }
        }
        public static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("You did not write anything, try again");
                }
            }
        }
        public static T GetValidEnumValue<T>(string prompt) where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(userInput) &&
                    Enum.TryParse<T>(userInput, ignoreCase: true, out var result) &&
                    Enum.IsDefined(typeof(T), result))
                {
                    return result;
                }

                Console.WriteLine("You did not put in a valid choice, try again");
            }
        }

    }
}
