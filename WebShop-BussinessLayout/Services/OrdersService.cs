using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_Domain.Models;
using WebShop_Domain.VwModel;

namespace WebShop_BussinessLayout.Services
{
    public class OrdersService : IOrdersRepository
    {
        private readonly WebShopContext _context;
        public OrdersService(WebShopContext context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetAllOrderssAsync()
        {
            try
            {
                List<Orders> orders = await _context.Orders.ToListAsync();

                if (orders == null)
                {
                    throw new ArgumentException(nameof(orders));
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Orders_Vm> CreateOrderAsync(Orders_Vm order_vm)
        {
            try
            {
                Orders order = new Orders()
                {
                    OrderDate = order_vm.OrderDate,
                    CustomerId = order_vm.CustomerId,
                    EmployeeId = order_vm.EmployeeId,
                    Freight = order_vm.Freight,
                    OrderId = order_vm.OrderId,
                    RequiredDate = order_vm.RequiredDate,
                    ShipAddress = order_vm.ShipAddress,
                    ShipCity = order_vm.ShipCity,
                    ShipCountry = order_vm.ShipCountry,
                    ShipName = order_vm.ShipName,
                    ShippedDate = order_vm.ShippedDate,
                    ShipPostalCode = order_vm.ShipPostalCode,
                    ShipRegion = order_vm.ShipRegion,
                    ShipVia = order_vm.ShipVia
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                var selectedProducts = await _context.Products.Where(x => order_vm.ProjectIds.Contains(x.ProductId)).ToListAsync();

                foreach (var product in selectedProducts)
                {
                    OrderDetails od = new OrderDetails();
                    od.ProductId = product.ProductId;
                    od.OrderId = order.OrderId;
                    od.UnitPrice = product.UnitPrice;
                    od.Quantity = product.QuantityPerUnit;

                    await _context.OrderDetails.AddAsync(od);
                    await _context.SaveChangesAsync();
                }

                return order_vm;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
