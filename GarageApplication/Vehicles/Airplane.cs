using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }
        public Airplane(VehicleColor color, int numberOfWheels, int numberOfEngines) : base(color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }


    }
}
