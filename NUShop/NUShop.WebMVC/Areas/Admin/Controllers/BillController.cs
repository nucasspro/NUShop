using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Data.Enums;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Extensions;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class BillController : BaseController
    {
        #region Injections

        private readonly IBillService _billService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<BillController> _logger;

        public BillController(IBillService billService, IHostingEnvironment hostingEnvironment, ILogger<BillController> logger)
        {
            _billService = billService;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        #endregion Injections

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillViewModel billViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(errors);
            }
            try
            {
                await _billService.CreateAsync(billViewModel);
                return new OkObjectResult(billViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail(BillDetailViewModel billDetailViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(errors);
            }
            try
            {
                await _billService.CreateDetailAsync(billDetailViewModel);
                return new OkObjectResult(billDetailViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int pageSize, string startDate, string endDate, int pageIndex = 1)
        {
            var pageResult = _billService.GetAllPaging(keyword, pageSize, startDate, endDate, pageIndex);
            return new OkObjectResult(pageResult);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var bill = _billService.GetDetailById(id);
            return new OkObjectResult(bill);
        }

        [HttpGet]
        public IActionResult GetBillDetails(int billId)
        {
            var billDetails = _billService.GetBillDetails(billId);
            return new OkObjectResult(billDetails);
        }

        [HttpGet]
        public IActionResult GetColorById(int id)
        {
            var color = _billService.GetColorById(id);
            return new OkObjectResult(color);
        }

        [HttpGet]
        public IActionResult GetColors()
        {
            var colors = _billService.GetColors();
            return new OkObjectResult(colors);
        }

        [HttpGet]
        public IActionResult GetSizeById(int id)
        {
            var size = _billService.GetSizeById(id);
            return new OkObjectResult(size);
        }

        [HttpGet]
        public IActionResult GetSizes()
        {
            var sizes = _billService.GetSizes();
            return new OkObjectResult(sizes);
        }

        [HttpGet]
        public IActionResult GetBillStatus()
        {
            var enums = ((BillStatus[])Enum.GetValues(typeof(BillStatus)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            var enums = ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BillViewModel billViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(errors);
            }
            try
            {
                await _billService.UpdateAsync(billViewModel);
                return new OkObjectResult(billViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int billId, BillStatus status)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(errors);
            }
            try
            {
                await _billService.UpdateStatusAsync(billId, status);
                return new OkObjectResult(billId);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDetail(int productId, int billId, int colorId, int sizeId)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(errors);
            }
            try
            {
                await _billService.DeleteDetailAsync(productId, billId, colorId, sizeId);
                return new OkObjectResult(billId);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPost]
        public IActionResult ExportExcel(int billId)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"Bill_{billId}.xlsx";
            // Template File
            string templateDocument = Path.Combine(sWebRootFolder, "templates", "BillTemplate.xlsx");

            string url = $"{Request.Scheme}://{Request.Host}/{"export-files"}/{sFileName}";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, "export-files", sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (FileStream templateDocumentStream = System.IO.File.OpenRead(templateDocument))
            {
                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["NUShopOrder"];
                    // Data Acces, load order header data.
                    var billDetail = _billService.GetDetailById(billId);

                    // Insert customer data into template
                    worksheet.Cells[4, 1].Value = "Customer Name: " + billDetail.CustomerName;
                    worksheet.Cells[5, 1].Value = "Address: " + billDetail.CustomerAddress;
                    worksheet.Cells[6, 1].Value = "Phone: " + billDetail.CustomerMobile;
                    // Start Row for Detail Rows
                    int rowIndex = 9;

                    // load order details
                    var orderDetails = _billService.GetBillDetails(billId);
                    int count = 1;
                    foreach (var orderDetail in orderDetails)
                    {
                        // Cell 1, Carton Count
                        worksheet.Cells[rowIndex, 1].Value = count.ToString();
                        // Cell 2, Order Number (Outline around columns 2-7 make it look like 1 column)
                        worksheet.Cells[rowIndex, 2].Value = orderDetail.Product.Name;
                        // Cell 8, Weight in LBS (convert KG to LBS, and rounding to whole number)
                        worksheet.Cells[rowIndex, 3].Value = orderDetail.Quantity.ToString();

                        worksheet.Cells[rowIndex, 4].Value = orderDetail.Price.ToString("N0");
                        worksheet.Cells[rowIndex, 5].Value = (orderDetail.Price * orderDetail.Quantity).ToString("N0");
                        // Increment Row Counter
                        rowIndex++;
                        count++;
                    }
                    decimal total = orderDetails.Sum(x => x.Quantity * x.Price);
                    worksheet.Cells[24, 5].Value = total.ToString("N0");

                    var numberWord = "Total amount (by word): " + TextHelper.ToString(total);
                    worksheet.Cells[26, 1].Value = numberWord;
                    var billDate = billDetail.DateCreated;
                    worksheet.Cells[28, 3].Value = billDate.Day + ", " + billDate.Month + ", " + billDate.Year;


                    package.SaveAs(file); //Save the workbook.
                }
            }
            return new OkObjectResult(url);
        }
    }
}