using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;

namespace NUShop.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        #region Injections
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IConfiguration _configuration;

        public ProductController(ILogger<ProductController> logger, IProductService productService, ICategoryService categoryService, IConfiguration configuration)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _configuration = configuration;
        }


        #endregion

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}