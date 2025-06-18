namespace GarageApplication.Vehicles
{
    public class Bus : Vehicle
    {
        public FuelType FuelType { get; }
        public Bus(VehicleColor color, int numberOfWheels, FuelType fuelType) : base(VehicleType.Bus, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return base.ToString() + $", Fuel type: {FuelType}";
        }

    }
}
