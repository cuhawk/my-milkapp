using Microsoft.EntityFrameworkCore;
using MyMilkApp.DAL.Data;
using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Repository.IRepositpry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Origin)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Origin)
                                 .Where(p => p.categoryId == categoryId)
                                 .ToListAsync();
        }
    }
}
