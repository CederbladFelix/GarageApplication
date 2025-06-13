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

            for(int i = 0; i < numberOfParkedVehicles; i++)
            {
                VehicleType vehicleType = UIService.GetValidEnumValue<VehicleType>
                    (
                        "What kind of vehicle is it?\n" +
                        "Choices:\n" +
                        $"{VehicleType.Airplane}\n" +
                        $"{VehicleType.Boat}\n" +
                        $"{VehicleType.Bus}\n" +
                        $"{VehicleType.Car}\n" +
                        $"{VehicleType.Motorcycle}\n" +
                        $"{VehicleType.Airplane}"
                    );
                VehicleColor vehicleColor = UIService.GetValidEnumValue<VehicleColor>
                    (
                        "What color is the vehicle?\n" +
                        "Choices:\n" +
                        $"{VehicleColor.Red}\n" +
                        $"{VehicleColor.Blue}\n" +
                        $"{VehicleColor.Black}\n" +
                        $"{VehicleColor.White}\n" +
                        $"{VehicleColor.Gray}\n" +
                        $"{VehicleColor.Silver}\n" +
                        $"{VehicleColor.Yellow}\n" +
                        $"{VehicleColor.Orange}\n" +
                        $"{VehicleColor.Brown}\n"
                    );

                int numberOfWheels = UIService.GetValidInteger("How many wheels doest the vehicle have?");
            }

            return null;
        }

        internal int AskForGarageSize()
        {
            return UIService.GetValidInteger("How big is the garage?");
        }
    }
}
