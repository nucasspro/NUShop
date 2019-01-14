using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;

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

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var bill = _billService.GetById(id);
            return new OkObjectResult(bill);
        }
    }
}