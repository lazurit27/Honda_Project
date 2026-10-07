using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Enums;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System.Drawing;

namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarProductsController(ICarProductRepository productRepository, ICarModelRepository modelRepository,  ICarBodyTypeRepository bodyRepository, ICarEngineTypeRepository engineRepository, [FromServices] IFileManager fileManager) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var carProducts = (await productRepository.GetAsync())
             .Select(x => new CarProductRow
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description,
                 Price = x.Price,
                 Year = x.Year,
                 Color = x.Color,
                 MainImageUrl = x.MainImageUrl,
                 IsAvailable = x.IsAvailable,
                 CarModelName = x.CarModel.Name,
                 CarBodyTypeName = x.CarBodyType.Name,
                 CarEngineTypeName = x.CarEngineType.Name,
                 Transmission = x.Transmission,
                 Drive = x.Drive
             }).ToList();
            return View(carProducts);
        }

        #region Create Operations

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ProductToCreate = new CarProductCreate();
            ProductToCreate.Models = await GetModelOptionsAsync();
            ProductToCreate.Bodies = await GetBodyOptionsAsync();
            ProductToCreate.Engines = await GetEngineOptionsAsync();
            return View(ProductToCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                model.Models = await GetModelOptionsAsync();
                model.Bodies = await GetBodyOptionsAsync();
                model.Engines = await GetEngineOptionsAsync();
                return View(model);
            }

            var MainImageUrl = await fileManager.SaveFileAsync(model.MainImage , AssetPath.Logos);

            var carProduct = new CarProduct { 

            Title = model.Title ,
            Description = model.Description,
            Price = model.Price,
            Year = model.Year,
            Color = model.Color,
            MainImageUrl = MainImageUrl,
            IsAvailable = true,
            Transmission = model.Transmission,
            Drive = model.Drive,
            CarModelId = model.CarModelId,
            CarBodyTypeId = model.CarBodyTypeId,
            CarEngineTypeId = model.CarEngineTypeId,
            };


            try
            {
                await productRepository.AddAsync(carProduct);
                TempData["Message"] = $"Car Product\"{carProduct.Title}\" has been created.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                fileManager.DeleteFile(MainImageUrl);
                throw;
            }
        }
        #endregion

        #region Edit Operations

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var oldProduct = await productRepository.GetAsync(id);

            if (oldProduct is null)
                return NotFound();

            var model = new CarProductEdit
            {
                Id = oldProduct.Id,
                Title = oldProduct.Title,
                Description = oldProduct.Description,
                Price = oldProduct.Price,
                Year = oldProduct.Year,
                Color = oldProduct.Color,
                ExistingModeMainImage = oldProduct.MainImageUrl,
                IsAvailable = true,
                Transmission = oldProduct.Transmission,
                Drive = oldProduct.Drive,
                CarModelId = oldProduct.CarModelId,
                CarBodyTypeId = oldProduct.CarBodyTypeId,
                CarEngineTypeId = oldProduct.CarEngineTypeId,
                Models = await GetModelOptionsAsync(),
                Bodies = await GetBodyOptionsAsync(),
                Engines = await GetEngineOptionsAsync(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarProductEdit model)
        {
            if (!ModelState.IsValid)
            {
                model.Models = await GetModelOptionsAsync();
                model.Bodies = await GetBodyOptionsAsync();
                model.Engines = await GetEngineOptionsAsync();
                return View(model);
            }

            var carProduct = await productRepository.GetAsync(model.Id);

            if (carProduct is null)
                return NotFound();

            carProduct.Title = model.Title;
            carProduct.Description = model.Description;
            carProduct.Price = model.Price;
            carProduct.Year = model.Year;
            carProduct.Color = model.Color;
            carProduct.IsAvailable = model.IsAvailable;
            carProduct.Transmission = model.Transmission;
            carProduct.Drive = model.Drive;
            carProduct.CarModelId = model.CarModelId;
            carProduct.CarBodyTypeId = model.CarBodyTypeId;
            carProduct.CarEngineTypeId = model.CarEngineTypeId;
            if (model.NewModelMainImage is { Length: > 0 })
            {

                var newLogoUrl = await fileManager.SaveFileAsync(model.NewModelMainImage, AssetPath.Logos);


                if (!string.IsNullOrEmpty(carProduct.MainImageUrl))
                {
                    fileManager.DeleteFile(carProduct.MainImageUrl);
                }

                carProduct.MainImageUrl = newLogoUrl;
            }

            await productRepository.UpdateAsync(carProduct);

            TempData["Message"] = $"Car Product \"{carProduct.Title}\" has been updated.";

            return RedirectToAction("Index");

        }

        #endregion

        #region Delete operations

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carModel = await productRepository.GetAsync(id);

            if (carModel is null)
                return NotFound();

            var model = new CarProductDelete()
            {
                Id = carModel.Id,
                Title = carModel.Title,
                Description = carModel.Description,
                Price = carModel.Price,
                Year = carModel.Year,
                Color = carModel.Color,
                IsAvailable = carModel.IsAvailable,
                Transmission = carModel.Transmission,
                Drive = carModel.Drive,
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carProduct = await productRepository.GetAsync(id);

            if (carProduct is null)
                return NotFound();

            await productRepository.DeleteAsync(id);
            if (!string.IsNullOrEmpty(carProduct.MainImageUrl))
            {
                fileManager.DeleteFile(carProduct.MainImageUrl);
            }
            TempData["Message"] = $"Car product\"{carProduct.Title}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods


        private async Task<List<SelectListItem>> GetModelOptionsAsync() =>
            (await modelRepository.GetAsync()).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

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

