using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.WebMVC.Models;

namespace NUShop.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        #region Injections
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBillService _billService;
        private readonly IConfiguration _configuration;

        public ProductController(
            ILogger<ProductController> logger, 
            IProductService productService, 
            ICategoryService categoryService,
            IBillService billService,
            IConfiguration configuration)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _billService = billService;
            _configuration = configuration;
        }


        #endregion

        [Route("products.html")]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(int id, int? pageSize, string sortBy, int pageIndex = 1)
        {
            ViewData["BodyClass"] = "category-page";
            if (pageSize == null || pageSize <= 0)
            {
                pageSize = _configuration.GetValue<int>("PageSize");
            }

            var catalog = new CatalogViewModel
            {
                SortBy = sortBy,
                PageSize = pageSize,
                Category = _categoryService.GetById(id),
                Products = _productService.GetAllPaging(id, string.Empty, pageIndex, pageSize.Value)
            };
            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Detail(int id, int? pageSize, string sortBy, int pageIndex = 1)
        {
            ViewData["BodyClass"] = "product-page";
            var productDetail = new ProductDetailViewModel
            {
                Product = _productService.GetById(id)
            };

            productDetail.Category = _categoryService.GetById(productDetail.Product.CategoryId);
            productDetail.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            productDetail.UpSellProducts = _productService.GetUpSellProducts(6);
            productDetail.ProductImages = _productService.GetImages(id);
            productDetail.Tags = _productService.GetProductTags(id);

            productDetail.Colors = _billService.GetColors().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            productDetail.Sizes = _billService.GetSizes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(productDetail);
        }
    }
}