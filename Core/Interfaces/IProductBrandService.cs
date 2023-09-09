using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductBrandService
    {
        Task<List<ProductBrand>> GetProductBrandsByAsync();

        Task<ProductBrand> GetProductBrandByIdAsync(Guid id);

        Task<List<ProductBrand>> AddProductBrandsAsync(ProductBrand productBrand);
        
        Task<List<ProductBrand>> UpdateProductBrandAsync(ProductBrand productBrand);
        Task<List<ProductBrand>> DeleteProductBrandsAsync(ProductBrand productBrand);


    }
}
