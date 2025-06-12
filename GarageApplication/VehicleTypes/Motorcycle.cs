using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(int registrationNumber, string color, int numberOfWheels, int cylinderVolume) : base(registrationNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override Vehicle Clone()
        {
            return new Motorcycle(RegistrationNumber, Color, NumberOfWheels, CylinderVolume);
        }
    }
}
