using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_Domain.Models;

namespace WebShop_Application.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly WebShopContext _context;

        public ProductController(IProductRepository productRepository, WebShopContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var getAllProducts = await _productRepository.GetAllProductsAsync();

            return View(getAllProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var getCategoryName = _context.Categories.ToList();
            ViewBag.CategoryName = new SelectList(getCategoryName, nameof(Categories.CategoryId), nameof(Categories.CategoryName));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products products)
        {

            var createProducts = await _productRepository.CreateProductAsync(products);

            return RedirectToAction("Index", createProducts);
        }
    }
}
