using Honda_Project.Models;

namespace Honda_Project.Repositories
{
    public interface ICarModelRepository
    {
        Task<List<CarModel>> GetAsync();
        Task<CarModel?> GetAsync(int id);
        Task AddAsync(CarModel newCarModel);
        Task UpdateAsync(CarModel carModel);
        Task DeleteAsync(int id);

    }
}
