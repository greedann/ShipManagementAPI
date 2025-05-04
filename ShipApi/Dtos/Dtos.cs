using ShipApplication.Models;
public record PassengerShipDto(string ImoNumber, string Name, double Length, double Width);
public record TankerShipDto(string ImoNumber, string Name, double Length, double Width, List<double> Tanks);
public record RefuelDto(int TankIndex, FuelType FuelType, double Amount);
