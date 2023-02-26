using Microsoft.AspNetCore.Mvc;
using WebShop_BussinessLayout.Interfaces;
using WebShop_BussinessLayout.Services;
using WebShop_Domain.Models;

namespace WebShop_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var getAllCategories = await _categoryRepository.GetAllCategoriesAsync();
            return View(getAllCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categories categories)
        {
            var createCategory = await _categoryRepository.CreateCategoryAsync(categories);

            return RedirectToAction("Index", createCategory);
        }
    }
}
