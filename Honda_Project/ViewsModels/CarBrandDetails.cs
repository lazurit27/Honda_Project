using Honda_Project.Models;

namespace Honda_Project.ViewsModels
{
    public class CarBrandDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CarModelListItem> CarModels { get; set; } = new();
    }
}
