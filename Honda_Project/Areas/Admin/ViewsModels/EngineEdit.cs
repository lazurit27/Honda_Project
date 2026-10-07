using Honda_Project.Enums;
using System.ComponentModel.DataAnnotations;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class EngineEdit
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Range(0.1, 1000)]
        public double? Volume { get; set; }
        [Range(1, 5000)]
        public int Horsepower { get; set; }
        public FuelType FuelType { get; set; }
        public List<string> Fuels { get; set; } = new();
    }
}
