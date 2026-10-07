using Honda_Project.Data;
using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Repositories
{
    public class CarModelRepository(AppDbContext context) : ICarModelRepository
    {
        public async Task AddAsync(CarModel newCarModel)
        {
            await context.CarModels.AddAsync(newCarModel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carModel = await context.CarModels.FindAsync(id);
            if (carModel != null)
            {
                context.CarModels.Remove(carModel);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<CarModel>> GetAsync() => await context.CarModels.AsNoTracking().Include(c => c.CarBrand).Include(p => p.CarProducts).ToListAsync();

        public async Task<CarModel?> GetAsync(int id) => await context.CarModels.AsNoTracking().Include(c => c.CarBrand).Include(p => p.CarProducts).FirstOrDefaultAsync(c => c.Id == id);

        public async Task UpdateAsync(CarModel carModel)
        {
           context.CarModels.Update(carModel);
            await context.SaveChangesAsync();
        }
    }
}
