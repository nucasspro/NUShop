using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class ProductQuantity : DomainEntity<int>
    {
        public ProductQuantity(int productId, int sizeId, int colorId,  int quantity)
        {
            ProductId = productId;
            SizeId = sizeId;
            ColorId = colorId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int Quantity { get; set; }
    }
}