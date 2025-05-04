using ShipApplication.Models;

namespace Tests
{
    public class TankerShipTest
    {
        [Fact]
        public void Constructor_ShouldInitializeTankerShip_WithValidParameters()
        {
            var tanks = new List<Tank>
            {
                new Tank(1000),
                new Tank(2000)
            };

            var tankerShip = new TankerShip("9074729", "Tanker1", 300, 50, tanks);

            Assert.Equal("9074729", tankerShip.ImoNumber);
            Assert.Equal("Tanker1", tankerShip.Name);
            Assert.Equal(300, tankerShip.Length);
            Assert.Equal(50, tankerShip.Width);
            Assert.Equal(tanks, tankerShip.Tanks);
        }

        [Fact]
        public void Tank_Refuel_ShouldIncreaseCurrentLevel_WhenValidAmountIsAdded()
        {
            var tank = new Tank(1000);

            tank.Refuel(FuelType.Diesel, 500);

            Assert.Equal(500, tank.CurrentLevel);
            Assert.Equal(FuelType.Diesel, tank.Type);
        }

        [Fact]
        public void Tank_Refuel_ShouldThrowInvalidOperationException_WhenExceedingCapacity()
        {
            var tank = new Tank(1000);

            Assert.Throws<InvalidOperationException>(() => tank.Refuel(FuelType.Diesel, 1500));
        }

        [Fact]
        public void Tank_Refuel_ShouldThrowInvalidOperationException_WhenAddingDifferentFuelType()
        {
            var tank = new Tank(1000);
            tank.Refuel(FuelType.Diesel, 500);

            Assert.Throws<InvalidOperationException>(() => tank.Refuel(FuelType.HeavyFuel, 200));
        }

        [Fact]
        public void Tank_Empty_ShouldResetCurrentLevelAndType()
        {
            var tank = new Tank(1000);
            tank.Refuel(FuelType.Diesel, 500);

            tank.Empty();

            Assert.Equal(0, tank.CurrentLevel);
            Assert.Null(tank.Type);
        }
    }
}