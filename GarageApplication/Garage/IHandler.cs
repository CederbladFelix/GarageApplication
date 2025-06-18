using GarageApplication.Vehicles;

namespace GarageApplication.Garage
{
    public interface IHandler
    {
        Vehicle? GetParkedVehicleByRegistration(string registrationNumber);
        bool IsGarageEmpty();
        bool IsGarageFull();
        void SaveGarage();
        void LoadGarage();
        int GetCapacity();
        void ListVehicles();
        bool ParkVehicle(Vehicle vehicle);
        void PrintCountByVehicleType();
        void PrintVehiclesByProperty(VehicleType? vehicleType = null, VehicleColor? vehicleColor = null, int? numberOfWheels = null);
        bool UnparkVehicle(Vehicle vehicle);
    }
}