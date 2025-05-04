namespace ShipApplication.Models
{
    public class PassengerShip : Ship
    {
        public List<string> Passengers { get; private set; } = new();

        public PassengerShip(string imoNumber, string name, double length, double width)
            : base(imoNumber, name, length, width) { }

        public void UpdatePassengers(List<string> newPassengers)
        {
            Passengers = newPassengers;
        }

        public void AddPasanger(string passanger)
        {
            Passengers.Add(passanger);
        }
    }
}
