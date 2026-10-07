using Honda_Project.Models;
using Honda_Project.ViewsModels;

namespace Honda_Project.Services
{
    public interface IProductService
    {
        Task<IEnumerable<CarProductListItem>> GetFilteredProductsAsync(ProductFilter filter);
        Task<ProductFilter> FillFilterOptionsAsync(ProductFilter filter);
    }
}

