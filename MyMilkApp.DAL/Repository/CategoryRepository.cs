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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategorysAsync()
        {
            return await _context.Categories
                                 .Include(c => c.Products)
                                 .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }
    }
}
