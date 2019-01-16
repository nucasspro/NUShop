using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Controllers.Components
{
    public class MobileMenuViewComponent : ViewComponent
    {
        #region Injections

        private readonly ICategoryService _categoryService;
        private readonly ILogger<MobileMenuViewComponent> _logger;

        public MobileMenuViewComponent(ICategoryService categoryService, ILogger<MobileMenuViewComponent> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        #endregion Injections

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}