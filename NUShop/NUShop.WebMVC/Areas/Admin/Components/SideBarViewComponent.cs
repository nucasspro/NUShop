using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Constants;
using NUShop.ViewModel.ViewModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        #region Injections

        private readonly IFunctionService _functionService;

        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        #endregion Injections

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            var roles = "Admin";
            List<FunctionViewModel> function;

            if (roles.Split(";").Contains(CommonConstants.AppRole.AdminRole))
            {
                var client = new RestClient("https://localhost:5003/api/function");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                //IRestResponse response = null;
                //client.ExecuteAsync(request, res => {
                //    if (res.IsSuccessful)
                //    {
                //        response = res;
                //    }
                //});
                var response = await client.ExecuteTaskAsync(request);
                if (response.IsSuccessful)
                {
                    function = JsonConvert.DeserializeObject<List<FunctionViewModel>>(response.Content);
                }
                else
                {
                    function = new List<FunctionViewModel>().ToList();
                }
            }
            else
            {
                function = new List<FunctionViewModel>().ToList();
            }
            return View(function);
        }
    }
}