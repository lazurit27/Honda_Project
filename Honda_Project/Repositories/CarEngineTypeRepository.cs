using Honda_Project.Data;
using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Repositories
{
    public class CarEngineTypeRepository(AppDbContext context) : ICarEngineTypeRepository
    {
        public async Task AddAsync(CarEngineType newCarEngineType)
        {
            await context.CarEngineTypes.AddAsync(newCarEngineType);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carEngineType = await context.CarEngineTypes.FindAsync(id);
            if (carEngineType != null)
            {
                context.CarEngineTypes.Remove(carEngineType);
                await context.SaveChangesAsync();
            }
        }

        public async Task<CarEngineType?> GetAsync(int id) => await context.CarEngineTypes.AsNoTracking().Include(p => p.CarProducts).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<CarEngineType>> GetAsync() => await context.CarEngineTypes.AsNoTracking().Include(p => p.CarProducts).ToListAsync();

        public async Task UpdateAsync(CarEngineType carEngineType)
        {
            context.CarEngineTypes.Update(carEngineType);
            await context.SaveChangesAsync();
        }
    }
}
