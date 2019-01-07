using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUShop.Data.Entities;
using System.Threading.Tasks;
using RestSharp;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var client = new RestClient("https://localhost:5003/api/account/Logout");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            return response.IsSuccessful ? Redirect("/Admin/Login/Index") : null;
        }
    }
}