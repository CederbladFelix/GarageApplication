using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Handler
    {
        private Garage<Vehicle> _garage;

        public Garage<Vehicle> Garage {  get { return _garage; } }

        public Handler(int capacity, Vehicle[]? vehicles)
        {
            _garage = new Garage<Vehicle>(capacity, vehicles);
        }

        public Vehicle? GetVehicleByRegistration(string registrationNumber)
        {
            return _garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
        }

        public void ParkVehicle(Vehicle vehicle) => _garage.ParkVehicle(vehicle);
        public void UnparkVehicle(Vehicle vehicle) => _garage.UnparkVehicle(vehicle);

        public Dictionary<string, int> GetCountByVehicleType()
        {
            return _garage
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(v => v.Key, v => v.Count());
        }

        public IEnumerable<Vehicle>? GetVehiclesByProperty(
            VehicleType? type = null,
            VehicleColor? color = null,
            int? numberOfWheels = null)
        {
            return _garage
                .Where(v =>
                    (type == null || v.Type == type) &&
                    (color == null || v.Color == color) &&
                    (numberOfWheels == null || v.NumberOfWheels == numberOfWheels));
        }
    }
}
