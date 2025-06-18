using GarageApplication.Vehicles;
using System.Text.Json;

namespace GarageApplication.Garage
{
    public class GarageStorage : IGarageStorage
    {
        private const string _filePath = "garage_save.json";

        public void SaveGarage(List<Vehicle> vehicles)
        {
            List<Dictionary<string, string>> vehiclesToSave = new();

            foreach (var vehicle in vehicles)
            {
                Dictionary<string, string> vehicleData = new();

                vehicleData.Add("Type", vehicle.Type.ToString());
                vehicleData.Add("Color", vehicle.Color.ToString());
                vehicleData.Add("NumberOfWheels", vehicle.NumberOfWheels.ToString());
                vehicleData.Add("RegistrationNumber", vehicle.RegistrationNumber.ToString());

                switch (vehicle)
                {
                    case Car car:
                        vehicleData.Add("NumberOfSeats", car.NumberOfSeats.ToString());
                        break;
                    case Boat boat:
                        vehicleData.Add("Length", boat.Length.ToString());
                        break;
                    case Bus bus:
                        vehicleData.Add("FuelType", bus.FuelType.ToString());
                        break;
                    case Motorcycle motorcycle:
                        vehicleData.Add("CylinderVolume", motorcycle.CylinderVolume.ToString());
                        break;
                    case Airplane airplane:
                        vehicleData.Add("NumberOfEngines", airplane.NumberOfEngines.ToString());
                        break;
                }

                vehiclesToSave.Add(vehicleData);
            }

            JsonSerializerOptions options = new();
            options.WriteIndented = true;

            string json = JsonSerializer.Serialize(vehiclesToSave, options);

            if (!File.Exists(_filePath) || File.ReadAllText(_filePath) != json)
            {
                File.WriteAllText(_filePath, json);
                Console.WriteLine("Garage saved.");
            }
            else
            {
                Console.WriteLine("No changes to save.");
            }
        }


        public List<Vehicle> LoadGarage()
        {
            List<Vehicle> vehicles = new();

            if (!File.Exists(_filePath))
                return vehicles;

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return vehicles;

            List<Dictionary<string, string>>? loadedData =
                JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);

            foreach (var data in loadedData!)
            {
                VehicleType type = Enum.Parse<VehicleType>(data["Type"]);
                VehicleColor color = Enum.Parse<VehicleColor>(data["Color"]);
                int numberOfWheels = int.Parse(data["NumberOfWheels"]);
                string registrationNumber = data["RegistrationNumber"];

                Vehicle? vehicle = null;

                switch (type)
                {
                    case VehicleType.Car:
                        int numberOfSeats = int.Parse(data["NumberOfSeats"]);
                        vehicle = new Car(color, numberOfWheels, numberOfSeats);
                        break;

                    case VehicleType.Boat:
                        int length = int.Parse(data["Length"]);
                        vehicle = new Boat(color, numberOfWheels, length);
                        break;

                    case VehicleType.Bus:
                        FuelType fuelType = Enum.Parse<FuelType>(data["FuelType"]);
                        vehicle = new Bus(color, numberOfWheels, fuelType);
                        break;

                    case VehicleType.Motorcycle:
                        int cylinderVolume = int.Parse(data["CylinderVolume"]);
                        vehicle = new Motorcycle(color, numberOfWheels, cylinderVolume);
                        break;

                    case VehicleType.Airplane:
                        int numberOfEngines = int.Parse(data["NumberOfEngines"]);
                        vehicle = new Airplane(color, numberOfWheels, numberOfEngines);
                        break;
                }

                if (vehicle != null)
                {
                    vehicle.SetRegistrationNumber(registrationNumber);
                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }
    }
}
