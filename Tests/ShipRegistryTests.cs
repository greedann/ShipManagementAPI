using ShipApplication.Models;


namespace Tests
{
    public class ShipRegistryTests
{
    [Fact]
    public void AddShip_WhenShipWithSameImoExists_ThrowsInvalidOperationException()
    {
        var registry = new ShipRegistry();
        var ship1 = new PassengerShip("9074729", "Ship1", 100, 20);
        var ship2 = new PassengerShip("9074729", "Ship2", 100, 20);
        registry.AddShip(ship1);

        Assert.Throws<InvalidOperationException>(() => registry.AddShip(ship2));
    }

    [Fact]
    public void UpdatePassengerList_WhenShipNotFound_ThrowsInvalidOperationException()
    {
        var registry = new ShipRegistry();

        Assert.Throws<InvalidOperationException>(() => registry.UpdatePassengerList("9074729", new List<string>()));
    }

    [Fact]
    public void RefuelTank_WithInvalidTankIndex_ThrowsIndexOutOfRangeException()
    {
        var registry = new ShipRegistry();
        var ship = new TankerShip("9074729", "Tanker1", 100.0, 20.0, new List<Tank> { new Tank(100) });
        registry.AddShip(ship);

        Assert.Throws<IndexOutOfRangeException>(() => registry.RefuelTank("9074729", 1, FuelType.Diesel, 50));
    }

    [Fact]
    public void EmptyTank_WhenShipNotFound_ThrowsInvalidOperationException()
    {
        var registry = new ShipRegistry();

        Assert.Throws<InvalidOperationException>(() => registry.EmptyTank("9074729", 0));
    }

    [Fact]
    public void GetShip_WhenShipNotFound_ThrowsKeyNotFoundException()
    {
        var registry = new ShipRegistry();

        Assert.Throws<KeyNotFoundException>(() => registry.GetShip("9074729"));
    }
}
}
