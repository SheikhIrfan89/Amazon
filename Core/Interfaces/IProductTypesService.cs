using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductTypesService
    {
        Task<List<ProductType>> GetProductTypeByAsync();
        Task<ProductType> GetProductTypeByIdAsync(Guid id);

        Task<List<ProductType>> AddProductTypeAsync(ProductType productType);
        Task<List<ProductType>> DeleteProductTypeAsync(ProductType productTyp);
        Task<List<ProductType>> UpdateProductTypeAsync(ProductType productTyp);
    }
}
