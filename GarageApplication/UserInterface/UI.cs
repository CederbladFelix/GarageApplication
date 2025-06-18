using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.UserInterface
{
    public class UI : IUI
    {
        private readonly IUIService UIService;

        public UI(IUIService uIService)
        {
            UIService = uIService;
        }

        public void PrintMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to garage app v1.0");
            Console.WriteLine("1. List parked vehicles\n" +
                                "2. List type of vehicle and how many of them are parked\n" +
                                "3. Add or Remove vehicles from the garage\n" +
                                "4. See if a vehicle is parked by registration\n" +
                                "5. List vehicles with certain qualities\n" +
                                "6. Exit the application");
        }

        public VehicleAction GetAddOrRemoveVehicleChoice()
        {
            VehicleAction answer = UIService.GetValidEnumValue<VehicleAction>("Write <Add> to add Vehicle\n" +
                                                                                "Write <Remove> to remove Vehicle");
            Console.WriteLine();

            return answer;
        }


        public void printVehicleIsNotInGarage()
        {
            Console.WriteLine("Vehicle is not in the garage");
        }

        public void printVehicleIsInGarage()
        {
            Console.WriteLine($"Vehicle is in the garage");
        }

        public (VehicleType? type, VehicleColor? color, int? wheels) GetPropertiesToSearchBy()
        {
            VehicleType? vehicleType = null;
            VehicleColor? vehicleColor = null;
            int? numberOfWheels = null;

            Console.WriteLine("Select filters to apply:");
            Console.WriteLine("1. Vehicle type");
            Console.WriteLine("2. Vehicle color");
            Console.WriteLine("3. Number of wheels");
            Console.WriteLine("Enter numbers separated by commas, for example 1,3):");

            string input = Console.ReadLine()?.Trim() ?? "";
            var choices = input
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToHashSet();

            if (choices.Contains("1"))
            {
                vehicleType = GetVehicleType("What kind of vehicle is it?");
            }

            if (choices.Contains("2"))
            {
                vehicleColor = GetVehicleColor("What color is the vehicle?");
            }

            if (choices.Contains("3"))
            {
                numberOfWheels = UIService.GetValidInteger("How many wheels does the vehicle have?");
            }

            return (vehicleType, vehicleColor, numberOfWheels);
        }

        public Vehicle? CreateVehicle()
        {
            VehicleColor vehicleColor = GetVehicleColor("What color is the vehicle?");
            Console.WriteLine();

            VehicleType vehicleType = GetVehicleType("What kind of vehicle is it?");
            Console.WriteLine();

            int numberOfWheels = 0;
            if (vehicleType != VehicleType.Boat)
            {
                numberOfWheels = UIService.GetValidInteger("How many wheels does the vehicle have?");
                Console.WriteLine();
            }

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
                        $"{FuelType.Electric}"
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
            Console.WriteLine("A vehicle has been registerd");
            Console.WriteLine(vehicle);
            Console.WriteLine();
            return vehicle;
        }

        public VehicleColor GetVehicleColor(string prompt)
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
                $"{VehicleColor.Brown}"
            );
        }

        public VehicleType GetVehicleType(string prompt)
        {
            return UIService.GetValidEnumValue<VehicleType>
            (
                $"{prompt}" + "\n" +
                "Choices:\n" +
                $"{VehicleType.Airplane}\n" +
                $"{VehicleType.Boat}\n" +
                $"{VehicleType.Bus}\n" +
                $"{VehicleType.Car}\n" +
                $"{VehicleType.Motorcycle}"
            );
        }
    }
}
