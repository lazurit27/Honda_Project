using Honda_Project.Enums;
using Honda_Project.Models;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarProductRow
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public string CarModelName { get; set; } = string.Empty;
        public string CarBodyTypeName { get; set; } = string.Empty;
        public string CarEngineTypeName { get; set; } = string.Empty;
        public TransmissionType Transmission { get; set; }
        public CarDriveType Drive { get; set; }
    }
}
