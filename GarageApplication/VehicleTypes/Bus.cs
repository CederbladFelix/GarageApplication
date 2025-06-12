using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Bus : Vehicle
    {
        public bool FuelType { get; }
        public Bus(int registrationNumber, string color, int numberOfWheels, bool fuelType) : base(registrationNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override Vehicle Clone()
        {
            return new Bus(RegistrationNumber, Color, NumberOfWheels, FuelType);
        }
    }
}
