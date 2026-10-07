namespace Honda_Project.Models
{
    public class CarBodyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CarProduct> CarProducts { get; set; } = new();
    }
}

