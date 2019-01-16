using Microsoft.AspNetCore.Mvc.Rendering;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Models
{
    public class CatalogViewModel
    {
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public CategoryViewModel Category { get; set; }
        public PagedResult<ProductViewModel> Products { get; set; }
        public List<SelectListItem> SortBys { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value="lastest", Text = "Lastest"},
            new SelectListItem(){Value="price", Text = "Price"},
            new SelectListItem(){Value="name", Text = "Name"}
        };

        public List<SelectListItem> PageSizes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "12",Text = "12"},
            new SelectListItem(){Value = "24",Text = "24"},
            new SelectListItem(){Value = "48",Text = "48"}
        };

    }
}
