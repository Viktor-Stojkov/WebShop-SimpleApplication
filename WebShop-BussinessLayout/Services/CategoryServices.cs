using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_Domain.Models;

namespace WebShop_BussinessLayout.Services
{
    public class CategoryServices : ICategoryRepository
    {
        private readonly WebShopContext _context;
        public CategoryServices(WebShopContext context)
        {
            _context = context;
        }

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            try
            {
                List<Categories> categories = await _context.Categories.ToListAsync();

                if (categories == null)
                {
                    throw new ArgumentException(nameof(categories));
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categories> CreateCategoryAsync(Categories category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return category;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
