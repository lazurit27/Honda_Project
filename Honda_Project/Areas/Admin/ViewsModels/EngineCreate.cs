using Honda_Project.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class EngineCreate
    {
        [Required(ErrorMessage = "Введите название двигателя")]
        [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
        public string Name { get; set; } = string.Empty;

        [Range(0, 10.0, ErrorMessage = "Объем двигателя должен быть от 0.1 до 10.0 л")]
        public double? Volume { get; set; }

        [Required(ErrorMessage = "Укажите мощность двигателя")]
        [Range(1, 5000, ErrorMessage = "Мощность должна быть от 1 до 5000 л.с.")]
        public int Horsepower { get; set; }

        [Required(ErrorMessage = "Выберите тип топлива")]
        public FuelType FuelType { get; set; }

    }
}
