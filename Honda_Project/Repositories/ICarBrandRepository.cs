using Honda_Project.Models;

namespace Honda_Project.Repositories
{
    public interface ICarBrandRepository
    {
        Task<List<CarBrand>> GetAsync();
        Task<CarBrand?> GetAsync(int id);
        Task AddAsync(CarBrand newCarBrand);
        Task UpdateAsync(CarBrand carBrand);
        Task DeleteAsync(int id);
    }
}
