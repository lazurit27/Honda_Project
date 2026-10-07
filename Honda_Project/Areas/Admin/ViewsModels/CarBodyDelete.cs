namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarBodyDelete
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;

        public List<string> CarProductsNames { get; set; } = new();
    }
}
