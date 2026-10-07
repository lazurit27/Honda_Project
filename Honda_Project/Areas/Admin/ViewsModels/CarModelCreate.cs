using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarModelCreate
    {
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(50, ErrorMessage = "Название не должно превышать 500 символов")]
        public string? Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Выберите файл!")]
        public IFormFile? ModelLogoFile { get; set; }
        [DisplayName("Brand")]
        public int BrandId { get; set; }
        public List<SelectListItem> Brands { get; set; } = new();
        
    }
}
