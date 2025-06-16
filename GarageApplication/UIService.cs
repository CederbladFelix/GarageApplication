using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class UIService : IUIService
    {
        public int GetValidInteger(string prompt)
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
        public string GetValidString(string prompt)
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
        public T GetValidEnumValue<T>(string prompt) where T : struct, Enum
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



        public int GetValidMenuChoice(int choices)
        {
            int answer = 0;
            bool running = true;
            while (running)
            {
                answer = GetValidInteger("Type in an answer 1-" + choices);
                if (answer < 0 || answer > choices)
                    Console.WriteLine("You did not put in a valid choice, try again");
                else
                    running = false;
            }

            return answer;
        }

        public string GetValidRegistrationNumber()
        {
            var regex = new Regex(@"^[A-Z]{3}[0-9]{3}$");
            string input = "";


            bool running = true;
            while (running)
            {
                input = GetValidString("Type in a registration number");

                if (regex.IsMatch(input.ToUpper()))
                    running = false;
                else
                    Console.WriteLine("You did not put in a valid registration number, try again");

            }

            return input;
        }
    }
}
