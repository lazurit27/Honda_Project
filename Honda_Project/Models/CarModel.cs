namespace Honda_Project.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ModelLogoUrl { get; set; } = string.Empty;
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; } = null!;
        public List<CarProduct> CarProducts { get; set; } = new();
    }
}
