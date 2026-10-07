using Honda_Project.Models;

namespace Honda_Project.Repositories
{
    public interface ICarBodyTypeRepository
    {
        Task<CarBodyType?> GetAsync(int id);
        Task<List<CarBodyType>> GetAsync();
        Task AddAsync(CarBodyType newCarBodyType);
        Task UpdateAsync(CarBodyType carBodyType);
        Task DeleteAsync(int id);
    }
}
