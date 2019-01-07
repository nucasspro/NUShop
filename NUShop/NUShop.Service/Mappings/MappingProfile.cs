using AutoMapper;
using NUShop.Data.Entities;
using NUShop.ViewModel.ViewModels;
using NUShop.Utilities.Helpers;

namespace NUShop.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Category

            CreateMap<CategoryViewModel, Category>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Category, CategoryViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Category

            #region Color

            CreateMap<ColorViewModel, Color>();
            CreateMap<Color, ColorViewModel>();

            #endregion Color

            #region Function

            CreateMap<FunctionViewModel, Function>();
            CreateMap<Function, FunctionViewModel>();

            #endregion Function

            #region ProductImage

            CreateMap<ProductImageViewModel, ProductImage>();
            CreateMap<ProductImage, ProductImageViewModel>();

            #endregion ProductImage

            #region ProductQuantity

            CreateMap<ProductQuantityViewModel, ProductQuantity>();
            CreateMap<ProductQuantity, ProductQuantityViewModel>();

            #endregion ProductQuantity

            #region Product

            CreateMap<ProductViewModel, Product>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Product, ProductViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Product

            #region Size

            CreateMap<SizeViewModel, Size>();
            CreateMap<Size, SizeViewModel>();

            #endregion Size

            #region Tag

            CreateMap<TagViewModel, Tag>();
            CreateMap<Tag, TagViewModel>();

            #endregion Tag

            #region WholePrice

            CreateMap<WholePriceViewModel, WholePrice>();
            CreateMap<WholePrice, WholePriceViewModel>();

            #endregion WholePrice
        }
    }
}