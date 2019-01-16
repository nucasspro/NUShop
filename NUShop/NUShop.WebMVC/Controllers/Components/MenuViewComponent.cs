using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Controllers.Components
{
    public class MenuViewComponent : ViewComponent
    {
        #region Injections

        private readonly ICategoryService _categoryService;
        private readonly ILogger<MenuViewComponent> _logger;

        public MenuViewComponent(ICategoryService categoryService, ILogger<MenuViewComponent> logger)
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