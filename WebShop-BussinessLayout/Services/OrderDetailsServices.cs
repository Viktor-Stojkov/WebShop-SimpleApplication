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
    public class OrderDetailsServices : IOrderDetailsRepository
    {
        private readonly WebShopContext _context;
        public OrderDetailsServices(WebShopContext context)
        {
            _context = context;
        }
        public async Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails)
        {
            try
            {
                await _context.OrderDetails.AddAsync(orderDetails);
                await _context.SaveChangesAsync();

                return orderDetails;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
