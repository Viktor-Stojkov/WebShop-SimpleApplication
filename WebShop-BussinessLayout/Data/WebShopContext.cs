using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Domain.Models;

namespace WebShop_BussinessLayout.Data
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VICTOR-LENOVO;Initial Catalog=WebShop-EmitKnowledge;Integrated Security=SSPI;TrustServerCertificate=True;");
        }
    }
}
