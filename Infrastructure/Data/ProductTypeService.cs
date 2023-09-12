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

       
        public async Task<List<ProductType>> AddProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();
                        
            return await _context.ProductTypes.ToListAsync();
        }

        
        public async Task<List<ProductType>> DeleteProductTypeAsync(ProductType prodstypes)
        {
            _context.ChangeTracker.Clear();
            _context.ProductTypes.Remove(prodstypes);
             _context.SaveChanges();
            
            return await (_context.ProductTypes.ToListAsync());
        }

        public async Task<List<ProductType>> GetProductTypeByAsync()
        {            
            return await _context.ProductTypes.ToListAsync();
                
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid id)
        {
            var prodty = _context.ProductTypes.Find(id);

            if (prodty != null)
                return prodty;
            else return null;


         //   return await _context.ProductTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

       

        public async Task<List<ProductType>> UpdateProductTypeAsync(ProductType productTyp)
        {
            _context.ChangeTracker.Clear();

            var prodty =  _context.ProductTypes.Attach(productTyp);
            prodty.State = EntityState.Modified;


            //_context.ProductTypes.Update(productTyp);
            _context.SaveChanges();
            return await (_context.ProductTypes.ToListAsync());

            
        }
    }
}
