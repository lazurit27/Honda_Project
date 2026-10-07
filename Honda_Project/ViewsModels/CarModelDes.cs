using Honda_Project.Models;

namespace Honda_Project.ViewsModels
{
    public class CarModelDes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ModelLogoUrl { get; set; } = string.Empty;
        public int CarBrandId { get; set; }
    }
}
