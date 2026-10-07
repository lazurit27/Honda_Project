using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Honda_Project.Enums;


namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarModelsController(ICarModelRepository modelRepository ,ICarBrandRepository brandRepository, [FromServices] IFileManager fileManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var carModels = (await modelRepository.GetAsync())
             .Select(x => new CarModelRow
             {
                 Id = x.Id,
                 Name = x.Name,
                 Description = x.Description,
                 ModelLogoUrl = x.ModelLogoUrl,
                 ProductsCount = x.CarProducts!.Count,
                 BrandName = x.CarBrand!.Name,
             }).ToList();
            return View(carModels);
        }

        #region Create Operations

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ModelToCreate = new CarModelCreate();
            ModelToCreate.Brands = await GetBrandOptionsAsync();
            return View(ModelToCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarModelCreate model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await GetBrandOptionsAsync();
                return View(model);
            }

            var logoUrl = await fileManager.SaveFileAsync(model.ModelLogoFile, AssetPath.Logos);

            var carModel = new CarModel
            {
                Name = model.Name,
                Description = model.Description,
                ModelLogoUrl = logoUrl,
                CarBrandId = model.BrandId
            };


            try
            {
                await modelRepository.AddAsync(carModel);
                TempData["Message"] = $"Car Model\"{carModel.Name}\" has been created.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                fileManager.DeleteFile(logoUrl);
                throw;
            }
        }
        #endregion

        #region Edit Operations

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var oldModel = await modelRepository.GetAsync(id);

            if (oldModel is null)
                return NotFound();

            var model = new CarModelEdit
            {
                Id = oldModel.Id,
                Name = oldModel.Name,
                Description = oldModel.Description,
                ExistingModelLogoUrl = oldModel.ModelLogoUrl,
                BrandId = oldModel.CarBrandId,
                Brands = await GetBrandOptionsAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarModelEdit model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await GetBrandOptionsAsync();
                return View(model);
            }

            var carModel = await modelRepository.GetAsync(model.Id);

            if (carModel is null)
                return NotFound();

            carModel.Name = model.Name;
            carModel.Description = model.Description;
            carModel.CarBrandId = model.BrandId;
            if (model.NewModelLogoFile is { Length: > 0 })
            {

                var newLogoUrl = await fileManager.SaveFileAsync(model.NewModelLogoFile, AssetPath.Logos);


                if (!string.IsNullOrEmpty(carModel.ModelLogoUrl))
                {
                    fileManager.DeleteFile(carModel.ModelLogoUrl);
                }

                carModel.ModelLogoUrl = newLogoUrl;
            }

            await modelRepository.UpdateAsync(carModel);

            TempData["Message"] = $"Car Model \"{carModel.Name}\" has been updated.";

            return RedirectToAction("Index");

        }

        #endregion

        #region Delete operations

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carModel = await modelRepository.GetAsync(id);

            if (carModel is null)
                return NotFound();

            var model = new CarModelDelete()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Description = carModel.Description,
                ModelLogoUrl = carModel.ModelLogoUrl,
                CarProductsNames = carModel.CarProducts.Select(p => p.Title).ToList()
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModel = await modelRepository.GetAsync(id);

            if (carModel is null)
                return NotFound();

            await modelRepository.DeleteAsync(id);
            if (!string.IsNullOrEmpty(carModel.ModelLogoUrl))
            {
                fileManager.DeleteFile(carModel.ModelLogoUrl);
            }
            foreach(var i in carModel.CarProducts)
            {
                if (!string.IsNullOrEmpty(i.MainImageUrl))
                {
                    fileManager.DeleteFile(i.MainImageUrl);
                }
            }
            TempData["Message"] = $"Car Brand and his products,models\"{carModel.Name}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods

        private async Task<List<SelectListItem>> GetBrandOptionsAsync() =>
            (await brandRepository.GetAsync()).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

        #endregion
    }
}
