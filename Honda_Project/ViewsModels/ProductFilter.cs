using Honda_Project.Enums;
using Honda_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Honda_Project.ViewsModels
{
    public class ProductFilter
    {
        public string? SearchTitle { get; set; }
        public int? SelectedModelId { get; set; }
        public int? SelectedBodyTypeId { get; set; }
        public int? SelectedEngineTypeId { get; set; }
        public int? SelectedBrandId { get; set; }
        public TransmissionType? SelectedTransmission { get; set; }
        public CarDriveType? SelectedDrive { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public IEnumerable<CarProductListItem> Products { get; set; } = new List<CarProductListItem>();
        public List<SelectListItem> Brands { get; set; } = new();
        public List<SelectListItem> Models { get; set; } = new();
        public List<SelectListItem> BodyTypes { get; set; } = new();
        public List<SelectListItem> EngineTypes { get; set; } = new();
    }
}
