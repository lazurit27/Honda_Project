using System.ComponentModel.DataAnnotations;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class CarBodyEdit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(500, ErrorMessage = "Название не должно превышать 500 символов")]
        public string Description { get; set; } = string.Empty;
    }
}
