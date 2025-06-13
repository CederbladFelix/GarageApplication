using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal class Bus : Vehicle
    {
        public FuelType FuelType { get; }
        public Bus(VehicleColor color, int numberOfWheels, FuelType fuelType) : base(color, numberOfWheels)
        {
            FuelType = fuelType;
        }


    }
}
