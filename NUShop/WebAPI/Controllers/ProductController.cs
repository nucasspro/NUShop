using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModels;
using NUShop.Utilities.Helpers;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ICategoryService categoryService , ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var model = _categoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);

            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(ProductViewModel productVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (productVm.Id == 0)
                {
                    _productService.Add(productVm);
                }
                else
                {
                    _productService.Update(productVm);
                }
                return new OkObjectResult(productVm);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _productService.Delete(id);

                return new OkObjectResult(id);
            }
        }
        [HttpPost]
        public IActionResult SaveQuantities(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productService.AddQuantity(productId, quantities);
            return new OkObjectResult(quantities);
        }

        [HttpGet]
        public IActionResult GetQuantities(int productId)
        {
            var quantities = _productService.GetQuantities(productId);
            return new OkObjectResult(quantities);
        }
        [HttpPost]
        public IActionResult SaveImages(int productId, string[] images)
        {
            _productService.AddImages(productId, images);
            return new OkObjectResult(images);
        }

        [HttpGet]
        public IActionResult GetImages(int productId)
        {
            var images = _productService.GetImages(productId);
            return new OkObjectResult(images);
        }

        [HttpPost]
        public IActionResult SaveWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _productService.AddWholePrice(productId, wholePrices);
            return new OkObjectResult(wholePrices);
        }

        [HttpGet]
        public IActionResult GetWholePrices(int productId)
        {
            var wholePrices = _productService.GetWholePrices(productId);
            return new OkObjectResult(wholePrices);
        }
    }
}
