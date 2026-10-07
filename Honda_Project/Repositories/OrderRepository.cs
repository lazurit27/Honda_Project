using Honda_Project.Data;
using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace Honda_Project.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task CreateAsync(Order newOrder)
        {
            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAsync() => await context.Orders.AsNoTracking().ToListAsync();

        public async Task<Order?> GetAsync(int id) => await context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

        public async Task<List<Order>> GetAsyncByUserId(string userId)
        {
            return await context.Orders.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
