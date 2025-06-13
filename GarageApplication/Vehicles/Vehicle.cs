using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal abstract class Vehicle
    {
        private static int _nextRegNumber = 1;
        public VehicleType Type { get; }
        public int RegistrationNumber { get; }
        public VehicleColor Color { get; }
        public int NumberOfWheels { get; }

        protected Vehicle(VehicleColor color, int numberOfWheels)
        {
            RegistrationNumber = _nextRegNumber++;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Registration number: {RegistrationNumber}, Color: {Color}";
        }

    }
}
