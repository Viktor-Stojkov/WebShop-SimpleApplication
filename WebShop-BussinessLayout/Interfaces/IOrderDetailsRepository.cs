using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Domain.Models;

namespace WebShop_BussinessLayout.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails);

    }
}
