using GarageApplication.Vehicles;

namespace GarageApplication
{
    internal interface IUI
    {
        IUIService UIService { get; }

        (VehicleAction, Vehicle) AddOrRemoveCreatedVehicle();
        Vehicle? CreateVehicle();
        (VehicleType? type, VehicleColor? color, int? wheels) GetPropertiesToSearchBy();
        VehicleColor GetVehicleColor(string prompt);
        VehicleType GetVehicleType(string prompt);
        void PrintMainMenu();
        void PrintNoVehiclesFoundByProperty();
        void printVehicleIsInGarage();
        void printVehicleIsNotInGarage();
        void PrintVehiclesByProperty(IEnumerable<Vehicle> vehicleSequence);
    }
}