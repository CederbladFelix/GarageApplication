using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class UI
    {

        internal void PrintMainMenu()
        {
            Console.WriteLine("Welcome to garage app v1.0");
            Console.WriteLine("1. List parked vehicles\n" +
                                "2. List type of vehicle and how many of them are parked\n" +
                                "3. Add or Remove vehicles from the garage\n" +
                                "4. See if a vehicle is parked by registration\n" +
                                "5. List vehicles with certain qualities\n" +
                                "0. Exit the application");
        }

        internal Vehicle[]? AskForAlreadyParkedVehicles()
        {

            int numberOfParkedVehicles = UIService.GetValidInteger("How many vehicles are parked");
            Vehicle[] vehicles = new Vehicle[numberOfParkedVehicles];

            for (int i = 0; i < numberOfParkedVehicles; i++)
            {
                vehicles[i] = UIService.CreateVehicle()!;
            }
            return vehicles;
        }

        internal int AskForGarageSize()
        {
            return UIService.GetValidInteger("How big is the garage?");
        }

        internal void PrintVehiclesInGarage(IEnumerable<Vehicle> vehiclesInGarage)
        {
            if (!vehiclesInGarage.Any())
            {
                Console.WriteLine("The garage is empty.");
                return;
            }

            foreach (var vehicle in vehiclesInGarage)
            {
                Console.WriteLine(vehicle);
            }
        }

        internal void PrintVehicleTypeAndCount(Dictionary<string, int> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                Console.WriteLine("The garage is empty.");
                return;
            }

            foreach (var vehicleCount in dictionary)
            {
                Console.WriteLine($"{vehicleCount.Key}: {vehicleCount.Value}");
            }
        }

        internal void PrintAddOrRemoveMenu()
        {
            Console.WriteLine("1. Add Vehicle\n" +
                    "2. Remove Vehicle");  

        }

        internal void printVehicleIsNotInGarage()
        {
            Console.WriteLine("Vehicle is not in the garage");
        }

        internal void printVehicleIsInGarage(Vehicle vehicle)
        {
            Console.WriteLine($"{vehicle} is in the garage");
        }

        internal (VehicleType? type, VehicleColor? color, int? wheels) GetPropertiesToSearchBy()
        {
            VehicleType? vehicleType = null;
            VehicleColor? vehicleColor = null;
            int? numberOfWheels = null;

            Console.WriteLine("Do you want to search by vehicle type? Type 1");
            string typeInput = Console.ReadLine();

            if (typeInput == "1")
            {
                VehicleType type = UIService.GetVehicleType("What kind of vehicle is it?");
            }

            Console.WriteLine("Do you want to search by Color type? Type 1");
            string colorInput = Console.ReadLine();

            if (colorInput == "1")
            {
                VehicleColor type = UIService.GetVehicleColor("What Color is the vehicle?");
            }

            Console.WriteLine("Do you want to search by how many wheels the vehicle has? Type 1");
            string wheelInput = Console.ReadLine();

            if (wheelInput == "1")
            {
                numberOfWheels = UIService.GetValidInteger("How many wheels does the vehicle have?");
            }

            return (vehicleType, vehicleColor, numberOfWheels);
        }

        internal void PrintNoVehiclesFoundByProperty()
        {
            Console.WriteLine("No vehicles was found in the garage with those properties");
        }

        internal void PrintVehiclesByProperty(IEnumerable<Vehicle> vehicleSequence)
        {
            foreach (var item in vehicleSequence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
