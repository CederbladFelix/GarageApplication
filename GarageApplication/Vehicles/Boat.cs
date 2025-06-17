using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(VehicleColor color, int numberOfWheels, int length) : base(VehicleType.Boat, color, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + $", Length: {Length}";
        }

    }
}
