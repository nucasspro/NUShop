using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using NUShop.Utilities.Constants;
using NUShop.Utilities.DTOs;
using NUShop.Utilities.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace NUShop.Service.Implements
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product, int> productRepository, IRepository<Tag, string> tagRepository,
                            IRepository<ProductQuantity, int> productQuantityRepository, IRepository<ProductImage, int> productImageRepository,
                            IRepository<WholePrice, int> wholePriceRepository, IRepository<ProductTag, int> productTagRepository,
                            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productQuantityRepository = productQuantityRepository;
            _productTagRepository = productTagRepository;
            _wholePriceRepository = wholePriceRepository;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            var productTags = new List<ProductTag>();
            if (string.IsNullOrEmpty(productViewModel.Tags))
                return productViewModel;

            var tags = productViewModel.Tags.Split(',');
            foreach (var t in tags)
            {
                var tagId = TextHelper.ToUnsignString(t);
                if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                {
                    var tag = new Tag
                    {
                        Id = tagId,
                        Name = t,
                        Type = CommonConstants.ProductTag
                    };
                    _tagRepository.Add(tag);
                }

                var productTag = new ProductTag
                {
                    TagId = tagId
                };
                productTags.Add(productTag);
            }

            var product = _mapper.Map<Product>(productViewModel);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Add(product);
            _unitOfWork.Commit();
            return productViewModel;
        }

        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productQuantityRepository.RemoveMultiple(_productQuantityRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
            _unitOfWork.Commit();
        }

        public List<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.GetAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            var totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = _mapper.Map<List<ProductViewModel>>(query);

            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ProductViewModel GetById(int id)
        {
            var product = _productRepository.GetById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            var productQuantities = _productQuantityRepository.GetAll(x => x.ProductId == productId);
            var productQuantitiesViewModel = _mapper.Map<List<ProductQuantityViewModel>>(productQuantities);
            return productQuantitiesViewModel;
        }

        public void Update(ProductViewModel productViewModel)
        {
            var productTags = new List<ProductTag>();

            if (!string.IsNullOrEmpty(productViewModel.Tags))
            {
                var tags = productViewModel.Tags.Split(',');
                foreach (var t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                    {
                        var tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.GetAll(x => x.Id == productViewModel.Id).ToList());
                    var productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
            }

            var product = _mapper.Map<Product>(productViewModel);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Update(product);
            _unitOfWork.Commit();
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            var productImages = _productImageRepository.GetAll(x => x.ProductId == productId);
            var productImagesViewModel = _mapper.Map<List<ProductImageViewModel>>(productImages);
            return productImagesViewModel;
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.RemoveMultiple(_productImageRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
            _unitOfWork.Commit();
        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.RemoveMultiple(_wholePriceRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
                });
            }
            _unitOfWork.Commit();
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            var wholePrices = _wholePriceRepository.GetAll(x => x.ProductId == productId);
            var wholePricesViewModel = _mapper.Map<List<WholePriceViewModel>>(wholePrices);
            return wholePricesViewModel;
        }

        public List<ProductViewModel> GetLastest(int top)
        {
            var products = _productRepository.GetAll(x => x.Status == Status.Active)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            var products = _productRepository
                .GetAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.GetById(id);
            var relatedProducts = _productRepository
                .GetAll(x => x.Status == Status.Active && x.Id != id && x.CategoryId == product.CategoryId)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var relatedProductsViewModel = _mapper.Map<List<ProductViewModel>>(relatedProducts);
            return relatedProductsViewModel;
        }

        public List<ProductViewModel> GetUpSellProducts(int top)
        {
            var products = _productRepository
                            .GetAll(x => x.PromotionPrice != null)
                            .OrderByDescending(x => x.DateModified).Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.GetAll();
            var productTags = _productTagRepository.GetAll();

            var query = from t in tags
                        join pt in productTags
                        on t.Id equals pt.TagId
                        where pt.ProductId == productId
                        select new TagViewModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        };
            return query.ToList();
        }

        public bool CheckAvailability(int productId, int size, int color)
        {
            var quantity = _productQuantityRepository.GetSingle(x => x.ColorId == color && x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.Quantity > 0;
        }
    }
}