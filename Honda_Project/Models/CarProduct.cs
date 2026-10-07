using Honda_Project.Enums;

namespace Honda_Project.Models
{
    public class CarProduct
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = null!;
        public int CarBodyTypeId { get; set; }
        public CarBodyType CarBodyType { get; set; } = null!;
        public int CarEngineTypeId { get; set; }
        public CarEngineType CarEngineType { get; set; } = null!;
        public TransmissionType Transmission { get; set; }
        public CarDriveType Drive { get; set; }
    }
}
