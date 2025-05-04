namespace ShipApplication.Models
{
    public enum FuelType { Diesel, HeavyFuel }

    public class Tank
    {
        public double Capacity { get; }
        public double CurrentLevel { get; private set; }
        public FuelType? Type { get; private set; }

        public Tank(double capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be positive.");
            Capacity = capacity;
        }

        public void Refuel(FuelType type, double amount)
        {
            if (CurrentLevel + amount > Capacity)
                throw new InvalidOperationException("Exceeds tank capacity.");

            if (Type != null && Type != type)
                throw new InvalidOperationException("Tank already contains different fuel type.");

            Type ??= type;
            CurrentLevel += amount;
        }

        public void Empty()
        {
            CurrentLevel = 0;
            Type = null;
        }
    }

    public class TankerShip : Ship
    {
        public List<Tank> Tanks { get; } = new();

        public TankerShip(string imoNumber, string name, double length, double width, List<Tank> tanks)
            : base(imoNumber, name, length, width)
        {
            Tanks = tanks ?? throw new ArgumentNullException(nameof(tanks));
        }
    }
}
