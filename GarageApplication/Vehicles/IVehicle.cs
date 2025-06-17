namespace GarageApplication.Vehicles
{
    public interface IVehicle
    {
        VehicleColor Color { get; }
        int NumberOfWheels { get; }
        string RegistrationNumber { get; }
        VehicleType Type { get; }

        string ToString();
    }
}