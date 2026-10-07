using Honda_Project.Models;

namespace Honda_Project.ViewsModels
{
    public class CarModelDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ModelLogoUrl { get; set; } = string.Empty;
        public int CarBrandId { get; set; }
        public List<CarProductListItem> CarProducts { get; set; } = new();
    }
}
