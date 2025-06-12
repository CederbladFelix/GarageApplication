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
        public int RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        protected Vehicle(int registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
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
