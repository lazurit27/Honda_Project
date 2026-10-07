using Honda_Project.Models;

namespace Honda_Project.Repositories
{
    public interface ICarEngineTypeRepository
    {
        Task<CarEngineType?> GetAsync(int id);
        Task AddAsync(CarEngineType newCarEngineType);
        Task<List<CarEngineType>> GetAsync();
        Task UpdateAsync(CarEngineType carEngineType);
        Task DeleteAsync(int id);
    }
}
