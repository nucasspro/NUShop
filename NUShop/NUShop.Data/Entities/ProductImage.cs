using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class ProductImage : DomainEntity<int>
    {
        public ProductImage(int productId, string path, string caption)
        {
            ProductId = productId;
            Path = path;
            Caption = caption;
        }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Path { get; set; }
        public string Caption { get; set; }
    }
}