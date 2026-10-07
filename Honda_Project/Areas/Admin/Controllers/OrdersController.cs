using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Honda_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController(IOrderRepository orderRepository, UserManager<IdentityUser> userManager) : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ordersList = await orderRepository.GetAsync();
            var ordersRows = new List<OrderRow>();

            foreach (var order in ordersList)
            {
                var user = await userManager.FindByIdAsync(order.UserId);

                ordersRows.Add(new OrderRow
                {
                    Id = order.Id,
                    UserName = user?.UserName ?? "Неизвестен",
                    CreatedAt = order.CreatedAt,
                    Status = order.Status,
                    ProductId = order.ProductId
                });
            }

            return View(ordersRows);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await orderRepository.GetAsync(id);

            if (order is null)
                return NotFound();

            var model = new OrderEdit
            {
                Id = order.Id,
                Status = order.Status
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] OrderEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var order = await orderRepository.GetAsync(model.Id);

            if (order is null)
                return NotFound();

            order.Status = model.Status;

            await orderRepository.UpdateAsync(order);

            TempData["Message"] = $"order \"{order.Id}\" has been updated.";

            return RedirectToAction("Index");
        }
    }
}
