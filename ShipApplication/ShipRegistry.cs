using ShipApplication.Models;

public class ShipRegistry
{
    private readonly Dictionary<string, Ship> _ships = new();

    public void AddShip(Ship ship)
    {
        if (_ships.ContainsKey(ship.ImoNumber))
            throw new InvalidOperationException("Ship with this IMO number already exists.");
        _ships[ship.ImoNumber] = ship;
    }

    public void UpdatePassengerList(string imo, List<string> passengers)
    {
        if (_ships.TryGetValue(imo, out var ship) && ship is PassengerShip ps)
        {
            ps.UpdatePassengers(passengers);
        }
        else
            throw new InvalidOperationException("Passenger ship not found.");
    }

    public void RefuelTank(string imo, int tankIndex, FuelType fuelType, double amount)
    {
        if (_ships.TryGetValue(imo, out var ship) && ship is TankerShip ts)
        {
            if (tankIndex < 0 || tankIndex >= ts.Tanks.Count)
                throw new IndexOutOfRangeException("Invalid tank index.");
            ts.Tanks[tankIndex].Refuel(fuelType, amount);
        }
        else
            throw new InvalidOperationException("Tanker ship not found.");
    }

    public void EmptyTank(string imo, int tankIndex)
    {
        if (_ships.TryGetValue(imo, out var ship) && ship is TankerShip ts)
        {
            if (tankIndex < 0 || tankIndex >= ts.Tanks.Count)
                throw new IndexOutOfRangeException("Invalid tank index.");
            ts.Tanks[tankIndex].Empty();
        }
        else
            throw new InvalidOperationException("Tanker ship not found.");
    }

    public Ship GetShip(string imo)
    {
        if (_ships.TryGetValue(imo, out var ship))
            return ship;
        throw new KeyNotFoundException($"No ship found with IMO number: {imo}");
    }

    public IEnumerable<Ship> GetAllShips()
    {
        return _ships.Values;
    }
}

