using Honda_Project.Enums;

namespace Honda_Project.ViewsModels
{
    public class EngineTypeDes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Volume { get; set; }
        public int Horsepower { get; set; }
        public string? FuelType { get; set; }
    }
}
