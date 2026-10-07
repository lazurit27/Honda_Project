using Honda_Project.Models;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarBrandDelete
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<string> CarModelsNames { get; set; } = new();
        public List<string> CarProductsNames { get; set; } = new();
    }
}
