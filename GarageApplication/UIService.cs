using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public static Vehicle? CreateVehicle()
        {
            VehicleColor vehicleColor = UIService.GetValidEnumValue<VehicleColor>
             (
                "What color is the vehicle?\n" +
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

            int numberOfWheels = UIService.GetValidInteger("How many wheels does the vehicle have?");

            VehicleType vehicleType = UIService.GetValidEnumValue<VehicleType>
            (
                "What kind of vehicle is it?\n" +
                "Choices:\n" +
                $"{VehicleType.Airplane}\n" +
                $"{VehicleType.Boat}\n" +
                $"{VehicleType.Bus}\n" +
                $"{VehicleType.Car}\n" +
                $"{VehicleType.Motorcycle}\n"
            );

            Vehicle? vehicle;

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
    }
}
