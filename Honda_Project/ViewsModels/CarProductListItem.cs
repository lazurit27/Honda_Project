namespace Honda_Project.ViewsModels
{
    public class CarProductListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
