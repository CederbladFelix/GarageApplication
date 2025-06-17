using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(VehicleColor color, int numberOfWheels, int cylinderVolume) : base(VehicleType.Motorcycle, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return base.ToString() + $", Cylinder volume: {CylinderVolume}";
        }

    }
}
