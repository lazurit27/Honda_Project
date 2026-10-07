using Honda_Project.Favorite;
using Honda_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Honda_Project.Controllers
{
    public class FavoriteController(ICarProductRepository productRepository) : Controller
    {
        private const string FAV_KEY = "Favorite";
        public async Task<IActionResult> Index()
        {

            var fav = HttpContext.Session.GetObject<List<FavoriteItem>>(FAV_KEY) ?? new();


            var ids = fav.Select(x => x.ProductID).ToList();
            var products = await productRepository.GetByIdsAsync(ids);

            var rows = products.Select(product => new FavoriteRow()
            {
                ProductID = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Year = product.Year,
                MainImageUrl = product.MainImageUrl,
                IsAvailable = product.IsAvailable,
            }).ToList();
            return View(rows);
        }

        [HttpPost]
        public IActionResult Remove()
        {
            HttpContext.Session.Remove(FAV_KEY);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Decrease(int id)
        {
            var fav = HttpContext.Session.GetObject<List<FavoriteItem>>(FAV_KEY) ?? new();
            var item = fav.FirstOrDefault(x => x.ProductID == id);
            if (item is not null)
            {

                fav.Remove(item);

                HttpContext.Session.SetObject(FAV_KEY, fav);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Toggle(int id)
        {
            var fav = HttpContext.Session.GetObject<List<FavoriteItem>>(FAV_KEY) ?? new();
            var item = fav.FirstOrDefault(x => x.ProductID == id);

            bool isAdded;

            if (item == null)
            {
                fav.Add(new FavoriteItem { ProductID = id });
                isAdded = true;
            }
            else
            {
                fav.Remove(item);
                isAdded = false;
            }

            HttpContext.Session.SetObject(FAV_KEY, fav);

            return Json(new { success = true, isAdded = isAdded, count = fav.Count });
        }
    }
}
