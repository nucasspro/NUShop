using Microsoft.AspNetCore.Mvc.Rendering;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.WebMVC.Models
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> RelatedProducts { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<ProductImageViewModel> ProductImages { set; get; }
        public List<ProductViewModel> UpSellProducts { get; set; }
        public List<ProductViewModel> LastestProducts { get; set; }
        public List<TagViewModel> Tags { set; get; }
        public List<SelectListItem> Colors { set; get; }
        public List<SelectListItem> Sizes { set; get; }
        public bool Available { set; get; }
    }
}