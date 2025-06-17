using GarageApplication.Garage;
using GarageApplication.Vehicles;
using Moq;
namespace GarageApplicationTests
{
    public class GarageTests
    {
        private Garage<Vehicle> garage;
        private Motorcycle motorcycle;
        private Car car;
        private Boat boat;
        public GarageTests()
        {
            garage = new(2);
            motorcycle = new(VehicleColor.Blue, 2, 5);
            car = new(VehicleColor.Red, 2, 5);
            boat = new(VehicleColor.Orange, 0, 10);
        }

        [Fact]
        public void ParkVehicle_Returns_True_When_Parking_Is_Successful()
        {
            //Arrange

            //Act
            bool result = garage.ParkVehicle(motorcycle);

            //Assert
            Assert.True(result);
            Assert.Contains(motorcycle, garage);

        }
        [Fact]
        public void ParkVehicle_Returns_False_When_Vehicle_Already_Is_Parked()
        {
            //Arrange

            //Act
            garage.ParkVehicle(motorcycle);
            bool result = garage.ParkVehicle(motorcycle);

            //Assert
            Assert.False(result);
            Assert.Contains(motorcycle, garage);

        }
        [Fact]
        public void ParkVehicle_Returns_False_When_Garage_Is_Full()
        {
            //Arrange

            //Act
            garage.ParkVehicle(motorcycle);
            garage.ParkVehicle(car);
            bool result = garage.ParkVehicle(boat);

            //Assert
            Assert.False(result);
            Assert.True(garage.isFull());

        }
    }
}
