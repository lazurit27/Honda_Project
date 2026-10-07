using Honda_Project.Data;
using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Repositories
{
    public class CarBrandRepository(AppDbContext context) : ICarBrandRepository
    {
        public async Task AddAsync(CarBrand newCarBrand)
        {
            await context.CarBrands.AddAsync(newCarBrand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carBrand = await context.CarBrands.FindAsync(id);
            if (carBrand != null)
            {
                context.CarBrands.Remove(carBrand);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<CarBrand>> GetAsync()=> await context.CarBrands.AsNoTracking().Include(c => c.CarModels).ToListAsync();

        public async Task<CarBrand?> GetAsync(int id) => await context.CarBrands.AsNoTracking()
        .Include(c => c.CarModels)
        .FirstOrDefaultAsync(c => c.Id == id);

        public async Task UpdateAsync(CarBrand carBrand)
        {
            context.CarBrands.Update(carBrand);
            await context.SaveChangesAsync();
        }
    }
}
