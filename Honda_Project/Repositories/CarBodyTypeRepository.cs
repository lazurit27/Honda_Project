using Honda_Project.Data;
using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Repositories
{
    public class CarBodyTypeRepository(AppDbContext context) : ICarBodyTypeRepository
    {
        public async Task AddAsync(CarBodyType newCarBodyType)
        {
            await context.CarBodyTypes.AddAsync(newCarBodyType);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carBodyType = await context.CarBodyTypes.FindAsync(id);
            if (carBodyType != null)
            {
                context.CarBodyTypes.Remove(carBodyType);
                await context.SaveChangesAsync();
            }
        }

        public async Task<CarBodyType?> GetAsync(int id) => await context.CarBodyTypes.AsNoTracking().Include(p => p.CarProducts)
        .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<CarBodyType>> GetAsync() => await context.CarBodyTypes.AsNoTracking().Include(p => p.CarProducts).ToListAsync();
        

        public async Task UpdateAsync(CarBodyType carBodyType)
        {
            context.CarBodyTypes.Update(carBodyType);
            await context.SaveChangesAsync();
        }
    }
}
