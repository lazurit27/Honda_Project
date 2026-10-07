using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Models;

namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarBodyController(ICarBodyTypeRepository repository, [FromServices] IFileManager fileManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var carBody = (await repository.GetAsync())
            .Select(x => new CarBodyRow
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ProductsCount = x.CarProducts!.Count,
            }).ToList();
            return View(carBody);
        }

        #region Create Operations

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CarBodyCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carBody = new CarBodyType
            {
                Name = model.Name,
                Description = model.Description,
            };

            try
            {
                await repository.AddAsync(carBody);
                TempData["Message"] = $"Car Body \"{carBody.Name}\" has been created.";
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
            var body = await repository.GetAsync(id);

            if (body is null)
                return NotFound();

            var model = new CarBodyEdit
            {
                Id = body.Id,
                Name = body.Name,
                Description = body.Description,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CarBodyEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carBody = await repository.GetAsync(model.Id);

            if (carBody is null)
                return NotFound();

            carBody.Name = model.Name;
            carBody.Description = model.Description;


            await repository.UpdateAsync(carBody);

            TempData["Message"] = $"Car Body \"{carBody.Name}\" has been updated.";

            return RedirectToAction("Index");

        }

        #endregion

        #region Delete operations

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carBody = await repository.GetAsync(id);

            if (carBody is null)
                return NotFound();

            var model = new CarBodyDelete()
            {
                Id = carBody.Id,
                Name = carBody.Name,
                Description = carBody.Description,
                IconUrl = carBody.IconUrl,
                CarProductsNames = carBody.CarProducts.Select(p => p.Title).ToList()
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carBody = await repository.GetAsync(id);

            if (carBody is null)
                return NotFound();

            await repository.DeleteAsync(id);
            if (!string.IsNullOrEmpty(carBody.IconUrl))
            {
                fileManager.DeleteFile(carBody.IconUrl);
            }
            foreach (var i in carBody.CarProducts)
            {
                if (!string.IsNullOrEmpty(i.MainImageUrl))
                {
                    fileManager.DeleteFile(i.MainImageUrl);
                }
            }

            TempData["Message"] = $"Car Body and his product \"{carBody.Name}\" has been deleted.";
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
