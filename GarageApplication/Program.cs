using GarageApplication.VehicleTypes;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage<Vehicle> vehicles = new(10);
            Console.WriteLine(vehicles);
        }
    }
}
