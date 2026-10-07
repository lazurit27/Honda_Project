using Honda_Project.Repositories;
using Honda_Project.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Honda_Project.Controllers
{
    public class CarBrandsController(ICarBrandRepository repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var carBrands = (await repository.GetAsync())
            .Select(x => new CarBrandListItem
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LogoUrl = x.LogoUrl,
            }).ToList();
            return View(carBrands);
        }


        public async Task<IActionResult> Details(int id)
        {
            var carBrand = await repository.GetAsync(id);
            if (carBrand is null)
                return NotFound();

            var model = new CarBrandDetails()
            {
                Id = id,
                Name = carBrand.Name,
                Description = carBrand.Description,
                LogoUrl = carBrand.LogoUrl,
                CarModels = carBrand.CarModels.Select(d => new CarModelListItem()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ModelLogoUrl = d.ModelLogoUrl,
                }).ToList()
            };

            return View(model);
        }
    }
}