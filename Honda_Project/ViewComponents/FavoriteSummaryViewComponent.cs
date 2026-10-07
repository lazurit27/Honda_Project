using Honda_Project.Favorite;
using Microsoft.AspNetCore.Mvc;

namespace Honda_Project.ViewComponents
{
    public class FavoriteSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var fav = HttpContext.Session.GetObject<List<FavoriteItem>>("Favorite") ?? new();

            int count = fav.Count;

            return View(count);
        }
    }
}
