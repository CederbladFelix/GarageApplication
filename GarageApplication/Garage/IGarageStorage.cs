using GarageApplication.Vehicles;

namespace GarageApplication.Garage
{
    public interface IGarageStorage
    {
        List<Vehicle> LoadGarage();
        void SaveGarage(List<Vehicle> vehicles);
    }
}