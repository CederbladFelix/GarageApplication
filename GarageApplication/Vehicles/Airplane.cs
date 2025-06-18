namespace GarageApplication.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }
        public Airplane(VehicleColor color, int numberOfWheels, int numberOfEngines) : base(VehicleType.Airplane, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of engines: {NumberOfEngines}";
        }

    }
}
