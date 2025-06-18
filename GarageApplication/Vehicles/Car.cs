namespace GarageApplication.Vehicles
{
    public class Car : Vehicle
    {
        public int NumberOfSeats { get; }
        public Car(VehicleColor color, int numberOfWheels, int numberOfSeats) : base(VehicleType.Car, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of seats: {NumberOfSeats}";
        }

    }
}
