using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> AddProductAsync(Product product)
        {
            _context.Products.AddAsync(product);
            _context.SaveChanges();

            return await _context.Products.ToListAsync();   
        }

        public  async Task<List<Product>> DeleteProductAsync(Product product)
        {

            _context.Products.Remove(product);
            _context.SaveChanges();
            return await (_context.Products.ToListAsync());

        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ; 
        }

        public async Task<IReadOnlyList<Product>>  GetProductsByAsync()
        {

          return await _context.Products.Include(p => p.Brand).Include(p => p.Types).ToListAsync();
            
        }

        public async Task<List<Product>> UpdateProductAsync(Product product)
        {
            _context.ChangeTracker.Clear();
            _context.Products.Update(product);
            _context.SaveChanges();

            return await (_context.Products.ToListAsync());
        }
    }
}
