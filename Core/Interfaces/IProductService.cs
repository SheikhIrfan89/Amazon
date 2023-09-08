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
        Task<List<Product>> GetProductsByAsync();
        Task<Product> GetProductByIdAsync(Guid id);
    }
}
