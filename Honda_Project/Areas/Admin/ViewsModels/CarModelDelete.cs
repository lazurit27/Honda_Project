namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarModelDelete
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ModelLogoUrl { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<string> CarProductsNames { get; set; } = new();
    }
}
