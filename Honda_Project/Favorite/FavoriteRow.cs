namespace Honda_Project.Favorite
{
    public class FavoriteRow
    {
        public int ProductID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
