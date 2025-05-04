using ShipApplication.Models;

namespace Tests
{
    public class PassengerShipTest
    {
        [Fact]
        public void InvalidIMONumber_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                new PassengerShip("1234568", "InvalidShip", 200, 30));
        }

        [Fact]
        public void AddPasanger_ShouldAddPassengerToList()
        {
            var passengerShip = new PassengerShip("9074729", "Test Ship", 300.0, 50.0);
            string newPassenger = "John Doe";

            passengerShip.AddPasanger(newPassenger);

            Assert.Single(passengerShip.Passengers);
            Assert.Equal(newPassenger, passengerShip.Passengers[0]);
        }

        [Fact]
        public void AddPasanger_ShouldAddMultiplePassengers()
        {
            var passengerShip = new PassengerShip("9074729", "Test Ship", 300.0, 50.0);
            string passenger1 = "John Doe";
            string passenger2 = "Jane Smith";

            passengerShip.AddPasanger(passenger1);
            passengerShip.AddPasanger(passenger2);

            Assert.Equal(2, passengerShip.Passengers.Count);
            Assert.Equal(passenger1, passengerShip.Passengers[0]);
            Assert.Equal(passenger2, passengerShip.Passengers[1]);
        }

        [Fact]
        public void UpdatePassengers_ShouldReplaceExistingPassengers()
        {
            var passengerShip = new PassengerShip("9074729", "Test Ship", 300.0, 50.0);
            var initialPassengers = new List<string> { "Alice", "Bob" };
            var newPassengers = new List<string> { "Charlie", "Diana" };

            passengerShip.UpdatePassengers(initialPassengers);

            passengerShip.UpdatePassengers(newPassengers);

            Assert.Equal(2, passengerShip.Passengers.Count);
            Assert.Equal("Charlie", passengerShip.Passengers[0]);
            Assert.Equal("Diana", passengerShip.Passengers[1]);
        }

        [Fact]
        public void Passengers_ShouldBeEmptyInitially()
        {
            var passengerShip = new PassengerShip("9074729", "Test Ship", 300.0, 50.0);

            Assert.Empty(passengerShip.Passengers);
        }

        [Fact]
        public void AddPasanger_ShouldNotThrowExceptionForDuplicatePassengers()
        {
            var passengerShip = new PassengerShip("9074729", "Test Ship", 300.0, 50.0);
            string passenger = "John Doe";

            passengerShip.AddPasanger(passenger);
            passengerShip.AddPasanger(passenger);

            Assert.Equal(2, passengerShip.Passengers.Count);
            Assert.Equal(passenger, passengerShip.Passengers[0]);
            Assert.Equal(passenger, passengerShip.Passengers[1]);
        }
    }
}