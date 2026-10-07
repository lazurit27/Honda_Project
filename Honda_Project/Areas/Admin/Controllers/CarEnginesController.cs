using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Enums;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.VisualStudio.TextTemplating;

namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarEnginesController(ICarEngineTypeRepository repository, [FromServices] IFileManager fileManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var carEngine = (await repository.GetAsync())
            .Select(x => new EngineRow
            {
                Id = x.Id,
                Name = x.Name,
                Volume = x.Volume,
                FuelType = x.FuelType,
                Horsepower = x.Horsepower,
                ProductsCount = x.CarProducts!.Count,
            }).ToList();
            return View(carEngine);
        }

        #region Create Operations

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EngineCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carEngine = new CarEngineType
            {
                Name = model.Name,
                Volume = model.Volume,
                FuelType = model.FuelType,
                Horsepower = model.Horsepower
            };

            try
            {
                await repository.AddAsync(carEngine);
                TempData["Message"] = $"Car Engine \"{carEngine.Name}\" has been created.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region Edit Operations

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Engine = await repository.GetAsync(id);

            if (Engine is null)
                return NotFound();

            var model = new EngineEdit
            {
                Id = Engine.Id,
                Name = Engine.Name,
                Volume = Engine.Volume,
                FuelType = Engine.FuelType,
                Horsepower = Engine.Horsepower
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EngineEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carEngine = await repository.GetAsync(model.Id);

            if (carEngine is null)
                return NotFound();

            carEngine.Name = model.Name;
            carEngine.Volume = model.Volume;
            carEngine.Horsepower = model.Horsepower;
            carEngine.FuelType = model.FuelType;


            await repository.UpdateAsync(carEngine);

            TempData["Message"] = $"Car Engine  \"{carEngine.Name}\" has been updated.";

            return RedirectToAction("Index");

        }

        #endregion

        #region Delete operations

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carEngine = await repository.GetAsync(id);

            if (carEngine is null)
                return NotFound();

            var model = new EngineDelete()
            {
                Id = carEngine.Id,
                Name = carEngine.Name,
                Volume = carEngine.Volume,
                Horsepower = carEngine.Horsepower,
                FuelType = carEngine.FuelType,
                CarProductsNames = carEngine.CarProducts.Select(p => p.Title).ToList()
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carEngine = await repository.GetAsync(id);

            if (carEngine is null)
                return NotFound();

            await repository.DeleteAsync(id);
            foreach (var i in carEngine.CarProducts)
            {
                if (!string.IsNullOrEmpty(i.MainImageUrl))
                {
                    fileManager.DeleteFile(i.MainImageUrl);
                }
            }

            TempData["Message"] = $"Car Engine and his product \"{carEngine.Name}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods


        #endregion

    }
}
