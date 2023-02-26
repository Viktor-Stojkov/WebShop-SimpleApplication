using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_Domain.Models;
using WebShop_Domain.VwModel;

namespace WebShop_Application.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IProductRepository _productRepository;
        private readonly WebShopContext _context;
        public OrdersController(IOrdersRepository ordersRepository, IOrderDetailsRepository orderDetailsRepository,IProductRepository productRepository, WebShopContext context)
        {
            _ordersRepository = ordersRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var getAllOrders = await _ordersRepository.GetAllOrderssAsync();
            return View(getAllOrders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Orders_Vm orders_Vm = new Orders_Vm();
            var getAllproducts = await _context.Products.ToListAsync();
            ViewBag.getAllProducts = new SelectList(getAllproducts, nameof(Products.ProductId), nameof(Products.ProductName));

            return View(orders_Vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Orders_Vm order)
        {
            var createOrder = await _ordersRepository.CreateOrderAsync(order);

            return RedirectToAction("Index", createOrder);
        }
    }
}
