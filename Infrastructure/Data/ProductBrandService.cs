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
    public class ProductBrandService : IProductBrandService
    {
        private readonly DataContext _context;

        public ProductBrandService(DataContext context)
        {
            _context = context;
        }
             

      
        public async Task<List<ProductBrand>> GetProductBrandsByAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }


        public async Task<ProductBrand> GetProductBrandByIdAsync(Guid id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProductBrand>> AddProductBrandsAsync(ProductBrand productBrand)
        {
            _context.ProductBrands.AddAsync(productBrand);
            _context.SaveChangesAsync();

            return await _context.ProductBrands.ToListAsync();

        }       

        public async Task<List<ProductBrand>> UpdateProductBrandAsync(ProductBrand productBrand)
        {
            _context.ChangeTracker.Clear();
            _context.ProductBrands.Update(productBrand);
            _context.SaveChangesAsync();

            return await _context.ProductBrands.ToListAsync();

        }

        public async Task<List<ProductBrand>> DeleteProductBrandsAsync(ProductBrand productBrand)
        {
            // var productBrand = _context.ProductBrands.FirstOrDefault(b => b.Id == id);
            _context.ProductBrands.Remove(productBrand);
            _context.SaveChanges();

            return await _context.ProductBrands.ToListAsync();

        }

    }
}
