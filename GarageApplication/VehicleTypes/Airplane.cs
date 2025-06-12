using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }
        public Airplane(string color, int numberOfWheels, int numberOfEngines) : base(color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override Vehicle Clone()
        {
            return new Airplane(Color, NumberOfWheels, NumberOfEngines);
        }

    }
}
