using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Injections

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        #endregion Injections

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var model = _categoryService.GetAll();
            return new OkObjectResult(model);
        }
    }
}