using Honda_Project.Data;
using Honda_Project.Models;
using Honda_Project.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Repositories
{
    public class CarProductRepository(AppDbContext context) : ICarProductRepository
    {
        public async Task AddAsync(CarProduct newCarProduct)
        {
            await context.CarProducts.AddAsync(newCarProduct);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carProduct = await context.CarProducts.FindAsync(id);
            if (carProduct != null)
            {
                context.CarProducts.Remove(carProduct);
                await context.SaveChangesAsync();
            }
        }

        public IQueryable<CarProduct> GetAllQueryable()
        {
            return context.CarProducts
         .Include(p => p.CarModel)
             .ThenInclude(m => m.CarBrand)
         .Include(p => p.CarBodyType)
         .Include(p => p.CarEngineType)
         .AsNoTracking();
        }

        public async Task<List<CarProduct>> GetAsync() => await context.CarProducts.AsNoTracking().Include(m => m.CarModel).ThenInclude(b => b.CarBrand).Include(b => b.CarBodyType).Include(e => e.CarEngineType).ToListAsync();

        public async Task<CarProduct?> GetAsync(int id) => await context.CarProducts.AsNoTracking().Include(m => m.CarModel).ThenInclude(b => b.CarBrand).Include(b => b.CarBodyType).Include(e => e.CarEngineType).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<CarProduct>> GetByIdsAsync(List<int> ids)
        {
            return await context.CarProducts
             .Where(x => ids.Contains(x.Id))
             .ToListAsync();
        }

        public async Task<List<CarProduct>?> GetRealtedProductsAsync(int carModelId, int excludeCarProductId)=>
            await context.CarProducts
        .Where(d => d.CarModelId == carModelId && d.Id != excludeCarProductId)
        .Take(5)
        .ToListAsync();

        public async Task UpdateAsync(CarProduct carProduct)
        {
            context.CarProducts.Update(carProduct);
            await context.SaveChangesAsync();
        }
    }
}
