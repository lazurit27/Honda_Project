using Honda_Project.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarProductEdit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0.01, 10000000.00, ErrorMessage = "Укажите корректную цену")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите год выпуска")]
        [Range(1900, 2026, ErrorMessage = "Укажите корректный год (1900–2026)")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Укажите цвет")]
        [MaxLength(30, ErrorMessage = "Название цвета не должно превышать 30 символов")]
        public string Color { get; set; } = string.Empty;

        public string? ExistingModeMainImage { get; set; }
        public IFormFile? NewModelMainImage { get; set; }

        public bool IsAvailable { get; set; } = true;


        public List<SelectListItem> Models { get; set; } = new();
        public List<SelectListItem> Engines { get; set; } = new();
        public List<SelectListItem> Bodies { get; set; } = new();


        [Required(ErrorMessage = "Выберите модель автомобиля")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите модель из списка")]
        public int CarModelId { get; set; }

        [Required(ErrorMessage = "Выберите тип кузова")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите тип кузова из списка")]
        public int CarBodyTypeId { get; set; }

        [Required(ErrorMessage = "Выберите тип двигателя")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите тип двигателя из списка")]
        public int CarEngineTypeId { get; set; }

        [Required(ErrorMessage = "Выберите тип трансмиссии")]
        public TransmissionType Transmission { get; set; }

        [Required(ErrorMessage = "Выберите тип привода")]
        public CarDriveType Drive { get; set; }
    }
}
