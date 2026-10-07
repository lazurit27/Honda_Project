using Honda_Project.Enums;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class EngineDelete
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Volume { get; set; }
        public int Horsepower { get; set; }
        public FuelType FuelType { get; set; }
        public List<string> CarProductsNames { get; set; } = new();
    }
}
