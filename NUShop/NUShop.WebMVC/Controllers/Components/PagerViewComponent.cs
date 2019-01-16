using Microsoft.AspNetCore.Mvc;
using NUShop.Utilities.DTOs;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}