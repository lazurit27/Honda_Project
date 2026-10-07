using Honda_Project.Enums;

namespace Honda_Project.Models
{
    public class CarEngineType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Volume { get; set; }
        public int Horsepower { get; set; }
        public FuelType FuelType { get; set; }
        public List<CarProduct> CarProducts { get; set; } = new();
    }
}
