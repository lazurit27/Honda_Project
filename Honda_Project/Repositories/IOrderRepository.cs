using Honda_Project.Models;

namespace Honda_Project.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order newOrder);
        Task UpdateAsync(Order order);
        Task<List<Order>> GetAsync();
        Task<Order?> GetAsync(int id);
        Task<List<Order>> GetAsyncByUserId (string userId);
    }
}
