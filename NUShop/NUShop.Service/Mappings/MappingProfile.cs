using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Service.ViewModels;

namespace NUShop.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();

            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}