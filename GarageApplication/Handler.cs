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
        public Garage<Vehicle> Garage { get; set; }

        public Handler(Garage<Vehicle> garage)
        {
            Garage = garage;
        }

        public Vehicle? GetVehicleByRegistration(int registrationNumber)
        {
            return Garage.GetParkedVehicles().FirstOrDefault(v => v?.RegistrationNumber == registrationNumber);
        }

        public Dictionary<string, int> GetCountByVehicleType()
        {
            return Garage.GetParkedVehicles()
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(v => v.Key, v => v.Count());
        }

        public IEnumerable<Vehicle>? GetVehiclesByProperty(
            VehicleType? type = null,
            VehicleColor? color = null,
            int? numberOfWheels = null)
        {
            return Garage.GetParkedVehicles()
                .Where(v =>
                    (type == null || v.Type == type) &&
                    (color == null || v.Color == color) &&
                    (numberOfWheels == null || v.NumberOfWheels == numberOfWheels))
                .Cast<Vehicle>();
        }
    }
}
