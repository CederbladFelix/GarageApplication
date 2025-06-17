using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Handler : IHandler
    {
        private IGarage<Vehicle> _garage;

        public Handler(IGarage<Vehicle> garage)
        {
            _garage = garage;
        }
        public bool ParkVehicle(Vehicle vehicle) => _garage.ParkVehicle(vehicle);
        public bool UnparkVehicle(Vehicle vehicle) => _garage.UnparkVehicle(vehicle);


        public void ListVehicles()
        {
            if (!_garage.Any())
            {
                Console.WriteLine("The garage is empty.");
                return;
            }
            foreach (var item in _garage)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintCountByVehicleType()
        {
            Dictionary<string, int> dictionary = GroupByVehicleType();

            foreach (var vehicleCount in dictionary)
            {
                Console.WriteLine($"{vehicleCount.Key}: {vehicleCount.Value}");
            }
        }

        private Dictionary<string, int> GroupByVehicleType()
        {
            return _garage
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(v => v.Key, v => v.Count());
        }

        public Vehicle? IsParkedVehicleByRegistration(string registrationNumber)
        {
            Vehicle? vehicle = _garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber.ToUpper());
            if (vehicle == null)
                return vehicle;
            else
                return vehicle;
        }


        public void PrintVehiclesByProperty(
            VehicleType? vehicleType = null,
            VehicleColor? vehicleColor = null,
            int? numberOfWheels = null)
        {
            List<Vehicle> list = _garage
                .Where(v =>
                    (vehicleType == null || v.Type == vehicleType) &&
                    (vehicleColor == null || v.Color == vehicleColor) &&
                    (numberOfWheels == null || v.NumberOfWheels == numberOfWheels))
                .ToList();

            if (list.Count == 0)
                Console.WriteLine("No vehicles was found in the garage with those properties");

            else
            {
                foreach (var vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }

        }
    }
}
