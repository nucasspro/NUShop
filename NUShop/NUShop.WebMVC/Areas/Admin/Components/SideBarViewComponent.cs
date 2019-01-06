using Microsoft.AspNetCore.Mvc;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModels;
using NUShop.Utilities.Constants;
using NUShop.WebMVC.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IFunctionService _functionService;

        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

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