using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsByAsync();
        Task<Product> GetProductByIdAsync(Guid id);

        Task<List<Product>> AddProductAsync(Product product);
        Task<List<Product>> UpdateProductAsync(Product product);

        Task<List<Product>> DeleteProductAsync(Product product);

    }
}
