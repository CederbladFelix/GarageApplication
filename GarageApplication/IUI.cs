using GarageApplication.Vehicles;

namespace GarageApplication
{
    internal interface IUI
    {
        IUIService UIService { get; }

        Vehicle? CreateVehicle();
        (VehicleType? type, VehicleColor? color, int? wheels) GetPropertiesToSearchBy();
        VehicleColor GetVehicleColor(string prompt);
        VehicleType GetVehicleType(string prompt);
        void PrintAddOrRemoveMenu();
        void PrintMainMenu();
        void PrintNoVehiclesFoundByProperty();
        void printVehicleIsInGarage();
        void printVehicleIsNotInGarage();
        void PrintVehiclesByProperty(IEnumerable<Vehicle> vehicleSequence);
        void PrintVehicleTypeAndCount(Dictionary<string, int> dictionary);
    }
}