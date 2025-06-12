using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal abstract class Vehicle
    {
        public int RegistrationNumber { get; set; } //Fixa unikt
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(int registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }


    }
}
