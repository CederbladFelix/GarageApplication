using GarageApplication.Garage;
using GarageApplication.Vehicles;
using Moq;
namespace GarageApplicationTests
{
    public class GarageTests
    {
        private const int capacity = 2;

        private Garage<Vehicle> garage;
        private Motorcycle motorcycle;
        private Car car;
        private Boat boat;

        public GarageTests()
        {
            garage = new(capacity);
            motorcycle = new(VehicleColor.Blue, 2, 5);
            car = new(VehicleColor.Red, 2, 5);
            boat = new(VehicleColor.Orange, 0, 10);
        }

        [Fact]
        public void Constructor_Should_Initialize_Properties()
        {
            Assert.Equal(capacity, garage.Capacity);

        }

        [Fact]
        public void IsEmpty_Returns_True_When_Garage_Has_No_Vehicles()
        {
            // Arrange

            // Act
            bool result = garage.isEmpty();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsFull_Returns_True_When_Garage_Is_At_Capacity()
        {
            // Arrange
            garage.ParkVehicle(motorcycle);
            garage.ParkVehicle(car);

            // Act
            bool result = garage.isFull();

            // Assert
            Assert.True(result);
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
        [Fact]
        public void UnParkVehicle_Returns_True_When_Vehicle_Is_Unparked()
        {
            //Arrange
            garage.ParkVehicle(motorcycle);
            

            //Act
            bool result = garage.UnparkVehicle(motorcycle);

            //Assert
            Assert.True(result);
            Assert.DoesNotContain(motorcycle, garage);

        }
        [Fact]
        public void UnParkVehicle_Returns_False_When_Vehicle_Is_Not_In_The_Garage()
        {
            //Arrange
            garage.ParkVehicle(boat);

            //Act
            bool result = garage.UnparkVehicle(motorcycle);

            //Assert
            Assert.False(result);
            Assert.DoesNotContain(motorcycle, garage);

        }
        [Fact]
        public void UnParkVehicle_Returns_False_When_Garage_Is_Empty()
        {
            //Arrange

            //Act
            bool result = garage.UnparkVehicle(motorcycle);

            //Assert
            Assert.False(result);
            Assert.True(garage.isEmpty());

        }
    }
}
