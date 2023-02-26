using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Domain.Models;
using WebShop_Domain.VwModel;

namespace WebShop_BussinessLayout.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetAllOrderssAsync();
        Task<Orders_Vm> CreateOrderAsync(Orders_Vm order);
    }
}
