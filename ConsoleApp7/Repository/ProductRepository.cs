using ConsoleApp7.DataAccess;
using ConsoleApp7.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.Repository
{
    public class ProductRepository
    {
        private readonly FakeApiDbContext _context;

        public ProductRepository(FakeApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public bool Add(Product product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool Update(Product product)
        {
            _context.Products.Update(product);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
    }
}
