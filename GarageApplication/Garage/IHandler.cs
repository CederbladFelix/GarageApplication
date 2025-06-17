using GarageApplication.Vehicles;

namespace GarageApplication.Garage
{
    public interface IHandler
    {
        bool IsGarageEmpty();
        Vehicle? GetParkedVehicleByRegistration(string registrationNumber);
        void ListVehicles();
        bool ParkVehicle(Vehicle vehicle);
        void PrintCountByVehicleType();
        void PrintVehiclesByProperty(VehicleType? vehicleType = null, VehicleColor? vehicleColor = null, int? numberOfWheels = null);
        bool UnparkVehicle(Vehicle vehicle);
    }
}