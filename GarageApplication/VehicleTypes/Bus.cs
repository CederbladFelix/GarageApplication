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
        public Bus(string color, int numberOfWheels, bool fuelType) : base(color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override Vehicle Clone()
        {
            return new Bus(Color, NumberOfWheels, FuelType);
        }
    }
}
