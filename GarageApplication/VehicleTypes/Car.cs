using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Car : Vehicle
    {
        public int NumberOfSeats { get; }
        public Car(int registrationNumber, string color, int numberOfWheels, int numberOfSeats) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override Vehicle Clone()
        {
            return new Car(RegistrationNumber, Color, NumberOfWheels, NumberOfSeats);
        }
    }
}
