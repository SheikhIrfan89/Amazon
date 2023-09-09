using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductTypeService : IProductTypesService
    {
        private readonly DataContext _context;

        public ProductTypeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ProductType>> GetProductTypeByAsync()
        {
            return await _context.ProductTypes.ToListAsync();
                
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid id)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
