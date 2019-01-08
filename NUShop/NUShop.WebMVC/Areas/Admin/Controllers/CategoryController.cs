using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
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
        public IActionResult GetAll()
        {
            var model = _categoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _categoryService.GetById(id);

            return new ObjectResult(model);
        }

        [HttpPut]
        public IActionResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            if (sourceId == targetId)
            {
                return new BadRequestResult();
            }

            _categoryService.UpdateParentId(sourceId, targetId, items);
            return new OkResult();
        }

        [HttpPost]
        public IActionResult SaveEntity(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            categoryViewModel.SeoAlias = TextHelper.ToUnsignString(categoryViewModel.Name);
            if (categoryViewModel.Id == 0)
            {
                _categoryService.Add(categoryViewModel);
            }
            else
            {
                _categoryService.Update(categoryViewModel);
            }
            return new OkObjectResult(categoryViewModel);
        }

        [HttpPost]
        public IActionResult ReOrder(int sourceId, int targetId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            if (sourceId == targetId)
            {
                return new BadRequestResult();
            }

            _categoryService.ReOrder(sourceId, targetId);
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }

            _categoryService.Delete(id);
            return new OkObjectResult(id);
        }
    }
}