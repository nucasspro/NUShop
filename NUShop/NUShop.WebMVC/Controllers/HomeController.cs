using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.WebMVC.Models;
using System.Diagnostics;

namespace NUShop.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        #region Injections

        private readonly IProductService _productService;
        private readonly IBlogService _blogService;
        private readonly ICommonService _commonService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IProductService productService, 
            IBlogService blogService, ICommonService commonService,
            ILogger<HomeController> logger)
        {
            _productService = productService;
            _blogService = blogService;
            _commonService = commonService;
            _logger = logger;
        }

        #endregion Injections

        public IActionResult Index()
        {
            ViewData["BodyClass"]= "cms-index-index cms-home-page";
            var home = new HomeViewModel
            {
                Title = "NUShop - Home",
                //home.MetaKeyword =
                //home.MetaDescription=
                BestSellers = _productService.GetHotProduct(4),
                LatestProducts = _productService.GetLastest(4),
                NewArrivals = _productService.GetHotProduct(8),
                LatestBlogs = _blogService.GetLastest(4),
                HomeSlides = _commonService.GetSlides("top")
            };
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}