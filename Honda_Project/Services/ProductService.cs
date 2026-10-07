using Honda_Project.Repositories;
using Honda_Project.ViewsModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Honda_Project.Services
{
    public class ProductService(ICarProductRepository productRepository, ICarBrandRepository brandRepository, ICarModelRepository modelRepository, ICarBodyTypeRepository bodyTypeRepository, ICarEngineTypeRepository engineTypeRepository) : IProductService
    {

        public async Task<ProductFilter> FillFilterOptionsAsync(ProductFilter filter)
        {
            var brands = await brandRepository.GetAsync();
            var models = await modelRepository.GetAsync();
            var bodyTypes = await bodyTypeRepository.GetAsync();
            var engineTypes = await engineTypeRepository.GetAsync();

            filter.Brands = brands.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();

            filter.Models = models.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name,
                Group = new SelectListGroup { Name = m.CarBrandId.ToString() }
            }).ToList();

            filter.BodyTypes = bodyTypes.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();

            filter.EngineTypes = engineTypes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            return filter;
        }

        public async Task<IEnumerable<CarProductListItem>> GetFilteredProductsAsync(ProductFilter filter)
        {
            var query = productRepository.GetAllQueryable();
            query = query.Where(p => p.IsAvailable);

            if (!string.IsNullOrWhiteSpace(filter.SearchTitle))
            {
                query = query.Where(p => p.Title.Contains(filter.SearchTitle));
            }

            if (filter.SelectedBrandId.HasValue && filter.SelectedBrandId > 0)
            {
                query = query.Where(p => p.CarModel.CarBrandId == filter.SelectedBrandId.Value);
            }

            if (filter.SelectedModelId.HasValue && filter.SelectedModelId > 0)
            {
                query = query.Where(p => p.CarModelId == filter.SelectedModelId.Value);
            }

            if (filter.SelectedBodyTypeId.HasValue && filter.SelectedBodyTypeId > 0)
            {
                query = query.Where(p => p.CarBodyTypeId == filter.SelectedBodyTypeId.Value);
            }

            if (filter.SelectedEngineTypeId.HasValue && filter.SelectedEngineTypeId > 0)
            {
                query = query.Where(p => p.CarEngineTypeId == filter.SelectedEngineTypeId.Value);
            }

            if (filter.SelectedTransmission.HasValue)
            {
                query = query.Where(p => p.Transmission == filter.SelectedTransmission.Value);
            }

            if (filter.SelectedDrive.HasValue)
            {
                query = query.Where(p => p.Drive == filter.SelectedDrive.Value);
            }

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            if (filter.MinYear.HasValue)
                query = query.Where(p => p.Year >= filter.MinYear.Value);

            if (filter.MaxYear.HasValue)
                query = query.Where(p => p.Year <= filter.MaxYear.Value);


            return await query.Select(p => new CarProductListItem
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Year = p.Year,
                Description = p.Description,
                MainImageUrl = p.MainImageUrl,
                IsAvailable = p.IsAvailable,
            }).ToListAsync();
        }
    }
}
