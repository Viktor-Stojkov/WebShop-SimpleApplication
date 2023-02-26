using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_Domain.Models;

namespace WebShop_BussinessLayout.Services
{
    public class ProductServices : IProductRepository
    {
        private readonly WebShopContext _context;
        public ProductServices(WebShopContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            try
            {
                List<Products> products = await _context.Products.Include(x => x.Category).ToListAsync();

                if (products == null)
                {
                    throw new ArgumentException(nameof(products));
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Products> CreateProductAsync(Products products)
        {
            try
            {
                await _context.Products.AddAsync(products);
                await _context.SaveChangesAsync();

                return products;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
