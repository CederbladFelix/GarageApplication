using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal abstract class Vehicle : ICloneable
    {
        private static int _nextRegNumber = 1;
        public int RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        protected Vehicle(string color, int numberOfWheels)
        {
            RegistrationNumber = _nextRegNumber++;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public abstract Vehicle Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
