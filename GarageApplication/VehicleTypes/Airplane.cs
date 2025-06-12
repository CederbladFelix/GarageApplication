using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.VehicleTypes
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public Airplane(int registrationNumber, string color, int numberOfWheels, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
