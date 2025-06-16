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

        public static Vehicle? CreateVehicle()
        {
            VehicleColor vehicleColor = GetVehicleColor("What color is the vehicle?");

            int numberOfWheels = UIService.GetValidInteger("How many wheels does the vehicle have?");

            VehicleType vehicleType = GetVehicleType("What kind of vehicle is it?");

            Vehicle ? vehicle;

            switch (vehicleType)
            {
                case VehicleType.Airplane:
                    int numberOfEngines = UIService.GetValidInteger("How many engines does the airplane have?");
                    vehicle = new Airplane(vehicleColor, numberOfWheels, numberOfEngines);
                    break;

                case VehicleType.Boat:
                    int length = UIService.GetValidInteger("What is the length of the boat?");
                    vehicle = new Boat(vehicleColor, numberOfWheels, length);
                    break;

                case VehicleType.Bus:
                    FuelType fuelType = UIService.GetValidEnumValue<FuelType>
                     (
                        "What fuel type does the bus have?\n" +
                        "Choices:\n" +
                        $"{FuelType.Petrol}\n" +
                        $"{FuelType.Diesel}\n" +
                        $"{FuelType.Electric}\n"
                    );
                    vehicle = new Bus(vehicleColor, numberOfWheels, fuelType);
                    break;

                case VehicleType.Car:
                    int numberOfSeats = UIService.GetValidInteger("How many seats does the car have?");
                    vehicle = new Car(vehicleColor, numberOfWheels, numberOfSeats);
                    break;

                case VehicleType.Motorcycle:
                    int cylinderVolume = UIService.GetValidInteger("What is the cylinder volume of the motorcycle?");
                    vehicle = new Motorcycle(vehicleColor, numberOfWheels, cylinderVolume);
                    break;

                default:
                    vehicle = null;
                    break;
            }
            return vehicle;
        }

        public static VehicleColor GetVehicleColor(string prompt)
        {
            return UIService.GetValidEnumValue<VehicleColor>
             (
                $"{prompt}" + "\n" +
                "Choices:\n" +
                $"{VehicleColor.Red}\n" +
                $"{VehicleColor.Blue}\n" +
                $"{VehicleColor.Black}\n" +
                $"{VehicleColor.White}\n" +
                $"{VehicleColor.Gray}\n" +
                $"{VehicleColor.Silver}\n" +
                $"{VehicleColor.Yellow}\n" +
                $"{VehicleColor.Orange}\n" +
                $"{VehicleColor.Brown}\n"
            );
        }

        public static VehicleType GetVehicleType(string prompt)
        {
            return UIService.GetValidEnumValue<VehicleType>
            (
                $"{prompt}" + "\n" +
                "Choices:\n" +
                $"{VehicleType.Airplane}\n" +
                $"{VehicleType.Boat}\n" +
                $"{VehicleType.Bus}\n" +
                $"{VehicleType.Car}\n" +
                $"{VehicleType.Motorcycle}\n"
            );
        }

        internal static int GetValidMenuChoice(int choices)
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

        internal static string GetValidRegistrationNumber()
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
