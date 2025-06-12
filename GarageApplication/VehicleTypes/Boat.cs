using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(string color, int numberOfWheels, int length) : base(color, numberOfWheels)
        {
            Length = length;
        }

        public override Vehicle Clone()
        {
            return new Boat(Color, NumberOfWheels, Length);
        }
    }
}
