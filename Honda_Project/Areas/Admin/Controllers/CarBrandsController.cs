using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Enums;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarBrandsController(ICarBrandRepository repository, [FromServices] IFileManager fileManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var carBrands = (await repository.GetAsync())
            .Select(x => new CarBrandRow
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LogoUrl = x.LogoUrl,
                ModelsCount = x.CarModels!.Count
            }).ToList();
            return View(carBrands);
        }

        #region Create Operations

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CarBrandCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var logoUrl = await fileManager.SaveFileAsync(model.LogoFile, AssetPath.Logos);

            var carBrand = new CarBrand
            {
                Name = model.Name,
                Description = model.Description,
                LogoUrl = logoUrl,
            };

            try
            {
                await repository.AddAsync(carBrand);
                TempData["Message"] = $"Car Brand \"{carBrand.Name}\" has been created.";
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
            var brand = await repository.GetAsync(id);

            if ( brand is null)
                return NotFound();

            var model = new CarBrandEdit
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description,
                ExistingLogoUrl = brand.LogoUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CarBrandEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carBrand = await repository.GetAsync(model.Id);

            if (carBrand is null)
                return NotFound();

            carBrand.Name = model.Name;
            carBrand.Description = model.Description;
            if (model.NewLogoFile is { Length: > 0 })
            {
                
                var newLogoUrl = await fileManager.SaveFileAsync(model.NewLogoFile, AssetPath.Logos);

               
                if (!string.IsNullOrEmpty(carBrand.LogoUrl))
                {
                    fileManager.DeleteFile(carBrand.LogoUrl);
                }

                carBrand.LogoUrl = newLogoUrl;
            }

            await repository.UpdateAsync(carBrand);

            TempData["Message"] = $"Car Brand \"{carBrand.Name}\" has been updated.";

            return RedirectToAction("Index");

        }

        #endregion

        #region Delete operations

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carBrand = await repository.GetAsync(id);

            if (carBrand is null)
                return NotFound();

            var model = new CarBrandDelete()
            {
                Id = carBrand.Id,
                Name = carBrand.Name,
                Description = carBrand.Description,
                LogoUrl = carBrand.LogoUrl,
                CarModelsNames = carBrand.CarModels.Select(x => x.Name).ToList(),
                CarProductsNames = carBrand.CarModels
                .SelectMany(m => m.CarProducts)
                .Select(p => p.Title)
                .ToList()
            };

            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carBrand = await repository.GetAsync(id);

            if (carBrand is null)
                return NotFound();

            await repository.DeleteAsync(id);
            if (!string.IsNullOrEmpty(carBrand.LogoUrl))
            {
                fileManager.DeleteFile(carBrand.LogoUrl);
            }
            foreach (var i in carBrand.CarModels)
            {
                if (!string.IsNullOrEmpty(i.ModelLogoUrl))
                {
                    fileManager.DeleteFile(i.ModelLogoUrl);
                }
            }
            foreach (var i in carBrand.CarModels.SelectMany(m => m.CarProducts))
            {
                if (!string.IsNullOrEmpty(i.MainImageUrl))
                {
                    fileManager.DeleteFile(i.MainImageUrl);
                }
            }
            TempData["Message"] = $"Car Brand and his product\"{carBrand.Name}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
