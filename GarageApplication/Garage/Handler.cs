using GarageApplication.Vehicles;

namespace GarageApplication.Garage
{
    public class Handler : IHandler
    {
        private readonly IGarage<Vehicle> _garage;
        private readonly IGarageStorage _garageStorage;

        public Handler(IGarage<Vehicle> garage, IGarageStorage garageStorage)
        {
            _garage = garage;
            _garageStorage = garageStorage;
        }
        public bool ParkVehicle(Vehicle vehicle) => _garage.ParkVehicle(vehicle);
        public bool UnparkVehicle(Vehicle vehicle) => _garage.UnparkVehicle(vehicle);

        public bool IsGarageEmpty()
        {
            return _garage.isEmpty();
        }
        public bool IsGarageFull()
        {
            return _garage.isFull();
        }
        
        public void SaveGarage()
        {
            var vehicles = _garage.ToList();
            _garageStorage.SaveGarage(vehicles);
        }

        public void LoadGarage()
        {
            var loadedVehicles = _garageStorage.LoadGarage();

            foreach (var vehicle in loadedVehicles)
            {
                _garage.ParkVehicle(vehicle);
            }
        }


        public int GetCapacity() => _garage.Capacity;


        public void ListVehicles()
        {
            if (IsGarageEmpty())
                Console.WriteLine("The garage is empty.");

            else
            {
                foreach (var item in _garage)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void PrintCountByVehicleType()
        {
            if (IsGarageEmpty())
                Console.WriteLine("The garage is empty");

            else
            {
                Dictionary<string, int> dictionary = GroupByVehicleType();

                foreach (var vehicleCount in dictionary)
                {
                    Console.WriteLine($"{vehicleCount.Key}: {vehicleCount.Value}");
                }
            }
        }

        private Dictionary<string, int> GroupByVehicleType()
        {
            return _garage
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(v => v.Key, v => v.Count());
        }

        public Vehicle? GetParkedVehicleByRegistration(string registrationNumber)
        {
            Vehicle? vehicle = _garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber.ToUpper());
            if (vehicle == null)
                return vehicle;
            else
                return vehicle;
        }


        public void PrintVehiclesByProperty(
            VehicleType? vehicleType = null,
            VehicleColor? vehicleColor = null,
            int? numberOfWheels = null)
        {
            List<Vehicle> list = _garage
                .Where(v =>
                    (vehicleType == null || v.Type == vehicleType) &&
                    (vehicleColor == null || v.Color == vehicleColor) &&
                    (numberOfWheels == null || v.NumberOfWheels == numberOfWheels))
                .ToList();

            if (list.Count == 0)
                Console.WriteLine("No vehicles was found in the garage with those properties");

            else
            {
                foreach (var vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }

        }
    }
}
