using GarageApplication.Vehicles;

namespace GarageApplication.UserInterface
{
    public interface IUI
    {
        Vehicle? CreateVehicle();
        VehicleAction GetAddOrRemoveVehicleChoice();
        (VehicleType? type, VehicleColor? color, int? wheels) GetPropertiesToSearchBy();
        VehicleColor GetVehicleColor(string prompt);
        VehicleType GetVehicleType(string prompt);
        void PrintMainMenu();
        void printVehicleIsInGarage();
        void printVehicleIsNotInGarage();
    }
}