using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.WebMVC.Models
{
    public class HomeViewModel
    {
        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }

        public List<ProductViewModel> BestSellers { get; set; }
        public List<ProductViewModel> LatestProducts { get; set; }
        public List<ProductViewModel> NewArrivals { get; set; }
        public List<BlogViewModel> LatestBlogs { get; set; }
        public List<SlideViewModel> HomeSlides { get; set; }
    }
}