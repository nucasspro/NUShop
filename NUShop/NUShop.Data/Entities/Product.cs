﻿using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public Product()
        {
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();
            ProductQuantities = new List<ProductQuantity>();
            WholePrices = new List<WholePrice>();
            BillDetails = new List<BillDetail>();
        }

        public Product(string name, int categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag,
            string tags, string unit, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();
            ProductQuantities = new List<ProductQuantity>();
            WholePrices = new List<WholePrice>();
            BillDetails = new List<BillDetail>();
        }

        public Product(int id, string name, int categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, string unit, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();
            ProductQuantities = new List<ProductQuantity>();
            WholePrices = new List<WholePrice>();
            BillDetails = new List<BillDetail>();
        }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }
        public virtual ICollection<ProductImage> ProductImages { set; get; }
        public virtual ICollection<ProductQuantity> ProductQuantities { set; get; }
        public virtual ICollection<WholePrice> WholePrices { set; get; }
        public virtual ICollection<BillDetail> BillDetails { set; get; }

        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
        public Status Status { set; get; }
    }
}