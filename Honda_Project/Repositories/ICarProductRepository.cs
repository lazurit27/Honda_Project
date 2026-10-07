using Honda_Project.Models;
using Honda_Project.ViewsModels;

namespace Honda_Project.Repositories
{
    public interface ICarProductRepository
    {
        Task<List<CarProduct>> GetAsync();
        Task<List<CarProduct>?> GetRealtedProductsAsync(int carModelId, int excludeCarProductId);
        Task<CarProduct?> GetAsync(int id);
        Task AddAsync(CarProduct newCarProduct);
        Task UpdateAsync(CarProduct carProduct);
        Task DeleteAsync(int id);
        IQueryable<CarProduct> GetAllQueryable();
        Task<List<CarProduct>> GetByIdsAsync(List<int> ids);
    }

}


