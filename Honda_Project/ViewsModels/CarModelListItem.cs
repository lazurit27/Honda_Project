namespace Honda_Project.ViewsModels
{
    public class CarModelListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ModelLogoUrl { get; set; } = string.Empty;
    }
}
