using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        #region Injections

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHostingEnvironment _hostingEnviroment;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
            ICategoryService categoryService,
            IHostingEnvironment hostingEnvironment,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _hostingEnviroment = hostingEnvironment;
            _logger = logger;
        }

        #endregion Injections

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API

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
        public IActionResult GetAllPaging(int? categoryId, string keyword, int pageSize, int pageIndex = 1)
        {
            var model = _productService.GetAllPaging(categoryId, keyword, pageIndex, pageSize);

            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);

            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            try
            {
                productViewModel.SeoAlias = TextHelper.ToUnsignString(productViewModel.Name);
                _productService.Add(productViewModel);
                return new OkObjectResult(productViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            try
            {
                productViewModel.SeoAlias = TextHelper.ToUnsignString(productViewModel.Name);
                _productService.Update(productViewModel);
                return new OkObjectResult(productViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
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

        //[HttpPost]
        //public IActionResult SaveQuantities(int productId, List<ProductQuantityViewModel> quantities)
        //{
        //    _productService.AddQuantity(productId, quantities);
        //    return new OkObjectResult(quantities);
        //}

        //[HttpGet]
        //public IActionResult GetQuantities(int productId)
        //{
        //    var quantities = _productService.GetQuantities(productId);
        //    return new OkObjectResult(quantities);
        //}

        //[HttpPost]
        //public IActionResult SaveImages(int productId, string[] images)
        //{
        //    _productService.AddImages(productId, images);
        //    return new OkObjectResult(images);
        //}

        //[HttpGet]
        //public IActionResult GetImages(int productId)
        //{
        //    var images = _productService.GetImages(productId);
        //    return new OkObjectResult(images);
        //}

        //[HttpPost]
        //public IActionResult SaveWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        //{
        //    _productService.AddWholePrice(productId, wholePrices);
        //    return new OkObjectResult(wholePrices);
        //}

        //[HttpGet]
        //public IActionResult GetWholePrices(int productId)
        //{
        //    var wholePrices = _productService.GetWholePrices(productId);
        //    return new OkObjectResult(wholePrices);
        //}

        [HttpPost]
        public async Task<IActionResult> ImportExcelAsync(IList<IFormFile> files, int categoryId)
        {
            if (files != null && files.Count > 0)
            {
                var file = files[0];
                var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string folder = _hostingEnviroment.WebRootPath + $@"\uploaded\excels";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = Path.Combine(folder, filename);

                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                await _productService.ImportExcelAsync(filePath, categoryId);
                return new OkObjectResult(filePath);
            }
            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult ExportExcel()
        {
            var webRootFolder = _hostingEnviroment.WebRootPath;
            var directory = Path.Combine(webRootFolder, "export-files");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = $"Product_{DateTime.Now:yyyyMMddhhmmss}.xlsx";
            var fileUrl = $"{Request.Scheme}://{Request.Host}/export-files/{fileName}";
            var file = new FileInfo(Path.Combine(directory, fileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(webRootFolder, fileName));
            }

            var products = _productService.GetAll();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products");
                worksheet.Cells["A1"].LoadFromCollection(products, true, TableStyles.Light1);
                worksheet.Cells.AutoFitColumns();
                package.Save(); 
            }
            return new OkObjectResult(fileUrl);
        }

        #endregion AJAX API
    }
}