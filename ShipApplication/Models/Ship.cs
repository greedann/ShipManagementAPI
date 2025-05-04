namespace ShipApplication.Models
{
    public abstract class Ship
    {
        public string ImoNumber { get; }
        public string Name { get; }
        public double Length { get; }
        public double Width { get; }

        protected Ship(string imoNumber, string name, double length, double width)
        {
            if (!IMOValidator.IsValid(imoNumber))
                throw new ArgumentException("Invalid IMO number.");
            if (length < 0)
                throw new ArgumentException("Length cannot be negative.");

            ImoNumber = imoNumber;
            Name = name;
            Length = length;
            Width = width;
        }
    }
}
