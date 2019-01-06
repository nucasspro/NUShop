using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using RestSharp;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        #region Injections

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ICategoryService categoryService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
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

       [ HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int pageSize, int pageIndex = 1)
        {
            //var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
            var client = new RestClient("https://localhost:5003/api/product/GetAllPaging");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            if (categoryId != null)
            {
                request.AddParameter("categoryId", categoryId, ParameterType.QueryString);
            }
            request.AddParameter("keyword", keyword,ParameterType.QueryString);
            request.AddParameter("page", pageIndex, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);

            var response = client.Execute(request);

            return new OkObjectResult(response.Content);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);

            return new OkObjectResult(model);
        }

        //[HttpPost]
        //public IActionResult SaveEntity(ProductViewModel productVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(allErrors);
        //    }
        //    else
        //    {
        //        productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
        //        if (productVm.Id == 0)
        //        {
        //            _productService.Add(productVm);
        //        }
        //        else
        //        {
        //            _productService.Update(productVm);
        //        }
        //        return new OkObjectResult(productVm);
        //    }
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new BadRequestObjectResult(ModelState);
        //    }
        //    else
        //    {
        //        _productService.Delete(id);

        //        return new OkObjectResult(id);
        //    }
        //}

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

        //[HttpPost]
        //public IActionResult ImportExcel(IList<IFormFile> files, int categoryId)
        //{
        //    if (files != null && files.Count > 0)
        //    {
        //        var file = files[0];
        //        var filename = ContentDispositionHeaderValue
        //                           .Parse(file.ContentDisposition)
        //                           .FileName
        //                           .Trim('"');

        //        string folder = _hostingEnvironment.WebRootPath + $@"\uploaded\excels";
        //        if (!Directory.Exists(folder))
        //        {
        //            Directory.CreateDirectory(folder);
        //        }
        //        string filePath = Path.Combine(folder, filename);

        //        using (FileStream fs = System.IO.File.Create(filePath))
        //        {
        //            file.CopyTo(fs);
        //            fs.Flush();
        //        }
        //        _productService.ImportExcel(filePath, categoryId);
        //        _productService.Save();
        //        return new OkObjectResult(filePath);
        //    }
        //    return new NoContentResult();
        //}
        //[HttpPost]
        //public IActionResult ExportExcel()
        //{
        //    string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //    string directory = Path.Combine(sWebRootFolder, "export-files");
        //    if (!Directory.Exists(directory))
        //    {
        //        Directory.CreateDirectory(directory);
        //    }
        //    string sFileName = $"Product_{DateTime.Now:yyyyMMddhhmmss}.xlsx";
        //    string fileUrl = $"{Request.Scheme}://{Request.Host}/export-files/{sFileName}";
        //    FileInfo file = new FileInfo(Path.Combine(directory, sFileName));
        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        //    }
        //    var products = _productService.GetAll();
        //    using (ExcelPackage package = new ExcelPackage(file))
        //    {
        //        // add a new worksheet to the empty workbook
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products");
        //        worksheet.Cells["A1"].LoadFromCollection(products, true, TableStyles.Light1);
        //        worksheet.Cells.AutoFitColumns();
        //        package.Save(); //Save the workbook.
        //    }
        //    return new OkObjectResult(fileUrl);
        //}

        #endregion AJAX API
    }
}