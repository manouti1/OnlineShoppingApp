using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Models;
using OnlineShoppingApp.Repositories;

namespace OnlineShoppingApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository,
                                  ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        // GET: /Products/
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View(new Product());
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                // Apply a sample discount logic if the product meets criteria.
                // For example, if the price is greater than 1000, assign a 5% discount.
                if (product.Price > 1000m)
                {
                    product.Discount = product.Price * 0.05m;
                }
                else
                {
                    product.Discount = 0;
                }

                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                ModelState.AddModelError("", "An error occurred while creating the product.");
                return View(product);
            }
        }
    }
}
