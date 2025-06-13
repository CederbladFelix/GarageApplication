using GarageApplication.Vehicles;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage<Vehicle> garage = new(10);
            Airplane airplane = new(VehicleColor.Orange, 10, 10);
            garage.ParkVehicle(airplane);
            IEnumerable<Vehicle> vehicles = garage.GetParkedVehicles();
            
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            var vehicleTypeCount = garage.GetCountByVehicleType();
            foreach (var item in vehicleTypeCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }


        }
    }
}
