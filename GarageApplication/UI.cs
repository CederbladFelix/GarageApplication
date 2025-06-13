using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class UI
    {
        internal Vehicle[]? AskForAlreadyParkedVehicles()
        {

            int numberOfParkedVehicles = UIService.GetValidInteger("How many vehicles are parked");
            Vehicle[] vehicles = new Vehicle[numberOfParkedVehicles];

            for (int i = 0; i < numberOfParkedVehicles; i++)
            {
                vehicles[i] = UIService.CreateVehicle()!;
            }
            return vehicles;
        }

        internal int AskForGarageSize()
        {
            return UIService.GetValidInteger("How big is the garage?");
        }
    }
}
