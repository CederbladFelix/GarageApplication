using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal class Car : Vehicle
    {
        public int NumberOfSeats { get; }
        public Car(VehicleColor color, int numberOfWheels, int numberOfSeats) : base(color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override Vehicle Clone()
        {
            return new Car(Color, NumberOfWheels, NumberOfSeats);
        }
    }
}
