namespace GarageApplication.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; }
        public Boat(VehicleColor color, int numberOfWheels, int length) : base(VehicleType.Boat, color, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + $", Length: {Length}";
        }

    }
}
