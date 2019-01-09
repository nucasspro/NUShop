using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUShop.Utilities.Constants;
using NUShop.ViewModel.ViewModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.WebMVC.Extensions;

namespace NUShop.WebMVC.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        #region Injections
        private readonly IFunctionService _functionService;
        private readonly ILogger<SideBarViewComponent> _logger;
        public SideBarViewComponent(ILogger<SideBarViewComponent>logger, IFunctionService functionService)
        {
            _logger = logger;
            _functionService = functionService;
        }

        #endregion Injections

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");

            List<FunctionViewModel> function;

            if (roles.Split(";").Contains(CommonConstants.AppRole.AdminRole))
            {
                function = await _functionService.GetAll(string.Empty);
            }
            else
            {
                function = new List<FunctionViewModel>().ToList();
            }
            return View(function);
        }

    }
}