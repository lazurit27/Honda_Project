using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Enums;
using Honda_Project.Models;
using Honda_Project.Repositories;
using Honda_Project.Services;
using Honda_Project.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

using OrderRowModel = Honda_Project.Areas.Admin.ViewsModels.OrderRow;

namespace Honda_Project.Controllers
{
    public class OrderController(ICarProductRepository productRepository,
    IOrderRepository orderRepository,
    UserManager<IdentityUser> userManager) : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

           
            var userOrders = await orderRepository.GetAsyncByUserId(userId);

            var currentUserName = User.Identity?.Name ?? "Пользователь";

            var ordersRows = userOrders.Select(order => new OrderRowModel
            {
                Id = order.Id,
                UserName = currentUserName,
                CreatedAt = order.CreatedAt,
                Status = order.Status,
                ProductId = order.ProductId
            }).ToList();

            return View(ordersRows);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create(int productId)
        {
            var product = await productRepository.GetAsync(productId);
            if (product == null)
            {
                TempData["Error"] = "Товар не найден.";
                return RedirectToAction("Index", "CarProducts");
            }

            return View(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateConfirmed(int productId)
        {

            var product = await productRepository.GetAsync(productId);
            if (product == null)
            {
                TempData["Error"] = "Товар не найден.";
                return RedirectToAction("Index", "CarProducts");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var order = new Order
            {
                ProductId = productId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };

            try
            {
                await orderRepository.CreateAsync(order);
                TempData["Message"] = "Ваш заказ успешно оформлен!";
                return RedirectToAction("Details", "CarProducts", new { id = productId });
            }
            catch
            {
                TempData["Error"] = "Произошла ошибка при оформлении заказа.";
                return RedirectToAction("Details", "CarProducts", new { id = productId });
            }
        }
    }
}
