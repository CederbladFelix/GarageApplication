using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(VehicleColor color, int numberOfWheels, int length) : base(color, numberOfWheels)
        {
            Length = length;
        }

    }
}
