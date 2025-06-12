using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat(int registrationNumber, string color, int numberOfWheels, int length) : base(registrationNumber, color, numberOfWheels)
        {
            Length = length;
        }
    }
}
