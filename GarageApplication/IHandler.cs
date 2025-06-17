using GarageApplication.Vehicles;

namespace GarageApplication
{
    internal interface IHandler
    {
        Vehicle? IsParkedVehicleByRegistration(string registrationNumber);
        void ListVehicles();
        bool ParkVehicle(Vehicle vehicle);
        void PrintCountByVehicleType();
        void PrintVehiclesByProperty(VehicleType? vehicleType = null, VehicleColor? vehicleColor = null, int? numberOfWheels = null);
        bool UnparkVehicle(Vehicle vehicle);
    }
}