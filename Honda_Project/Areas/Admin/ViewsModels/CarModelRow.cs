namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarModelRow
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ModelLogoUrl { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public int ProductsCount { get; set; }

    }
}
