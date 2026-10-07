using Honda_Project.Repositories;
using Honda_Project.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Honda_Project.Controllers
{

    public class CarModelsController(ICarModelRepository repository) : Controller
    {
        public async Task<IActionResult> Details(int id)
        {
            var carModel = await repository.GetAsync(id);
            if (carModel is null)
                return NotFound();

            var model = new CarModelDetails()
            {
                Id = id,
                Name = carModel.Name,
                Description = carModel.Description,
                ModelLogoUrl = carModel.ModelLogoUrl,
                CarBrandId =  carModel.CarBrandId,
                CarProducts = carModel.CarProducts?.Select(d => new CarProductListItem()
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    MainImageUrl = d.MainImageUrl,
                    Price = d.Price,
                    Year = d.Year,
                    IsAvailable = d.IsAvailable
                }).ToList() ?? []
            };

            return View(model);
        }
    }
}