using  Honda_Project.Enums;

namespace Honda_Project.ViewsModels
{
    public class CarProductDetails
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public int CarModelId { get; set; }
        public CarModelDes? CarModel { get; set; } = null!;
        public int CarBodyTypeId { get; set; }
        public BodyTypeDes? CarBodyType { get; set; } = null!;
        public int CarEngineTypeId { get; set; }
        public EngineTypeDes? CarEngineType { get; set; } = null!;
        public string? Transmission { get; set; }
        public string? Drive { get; set; }
        public List<CarProductListItem>? RelatedCarProducts { get; set; }
    }
}
