using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUShop.Service.ViewModels.AccountViewModels;
using RestSharp;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Authentication(LoginViewModel loginViewModel)
        {
            var client = new RestClient("https://localhost:5003/api/account/Login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(loginViewModel), ParameterType.RequestBody);
            var response = client.Execute(request);
            return new OkObjectResult(response.Content);
        }
    }
}