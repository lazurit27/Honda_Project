using Honda_Project.Repositories;
using Honda_Project.Services;
using Honda_Project.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Controllers
{
    public class CarProductsController(ICarProductRepository productRepository, IProductService productService, ICarBrandRepository brandRepository, ICarModelRepository modelRepository, ICarBodyTypeRepository bodyRepository, ICarEngineTypeRepository engineRepository ) : Controller
    {




        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ProductFilter filter) { 

            filter.Products = await productService.GetFilteredProductsAsync(filter);

            filter = await productService.FillFilterOptionsAsync(filter);

            return View(filter);
        }
        public async Task<IActionResult> Details(int id)
        {



            var carProduct = await productRepository.GetAsync(id);
            if (carProduct is null)
                return NotFound();

            var realtedProducts = await productRepository.GetRealtedProductsAsync(carProduct.CarModelId, id);

            var model = new CarProductDetails()
            {
                Id = carProduct.Id,
                Title = carProduct.Title,
                Description = carProduct.Description,
                Price = carProduct.Price,
                Year = carProduct.Year,
                Color = carProduct.Color,
                MainImageUrl = carProduct.MainImageUrl,
                IsAvailable = carProduct.IsAvailable,
                CarBodyTypeId = carProduct.CarBodyTypeId,
                CarEngineTypeId = carProduct.CarEngineTypeId,
                CarModelId = carProduct.CarModelId,
                RelatedCarProducts = realtedProducts?.Select(d => new CarProductListItem()
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    MainImageUrl = d.MainImageUrl,
                    Price = d.Price,
                    Year = d.Year,
                    IsAvailable = d.IsAvailable
                }).ToList() ?? [],
                Transmission = carProduct.Transmission.ToString(),
                Drive = carProduct.Drive.ToString(),

                CarEngineType = carProduct.CarEngineType is { } engine ? new EngineTypeDes
                {
                    Id = engine.Id,
                    Name = engine.Name ?? "Not Found",
                    Volume = engine.Volume,
                    Horsepower = engine.Horsepower,
                    FuelType = engine.FuelType.ToString()
                } : null,

                CarBodyType = carProduct.CarBodyType is { } body ? new BodyTypeDes
                {
                    Id = body.Id,
                    Name = body.Name ?? "Not Found",
                } : null,

                CarModel = carProduct.CarModel is { } modelNav ? new CarModelDes
                {
                    Id = modelNav.Id,
                    Name = modelNav.Name ?? "Not Found",
                    ModelLogoUrl = modelNav.ModelLogoUrl,
                    CarBrandId = modelNav.CarBrandId
                } : null


            };

            return View(model);
        }


        #region Private Methods
        private async Task<List<SelectListItem>> GetBrandOptionsAsync() =>
            (await brandRepository.GetAsync()).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();


        private async Task<List<SelectListItem>> GetModelOptionsAsync()
        {
            var models = await modelRepository.GetAsync();

            return models.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Group = new SelectListGroup { Name = c.CarBrandId.ToString() }
            }).ToList();
        }


        private async Task<List<SelectListItem>> GetBodyOptionsAsync() =>
            (await bodyRepository.GetAsync()).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

        private async Task<List<SelectListItem>> GetEngineOptionsAsync() =>
            (await engineRepository.GetAsync()).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

        #endregion
    }
}