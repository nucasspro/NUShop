using NUShop.Infrastructure.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUShop.Data.Entities
{
    public class WholePrice : DomainEntity<int>
    {
        public WholePrice(int productId, int fromQuantity, int toQuantity, decimal price)
        {
            ProductId = productId;
            FromQuantity = fromQuantity;
            ToQuantity = toQuantity;
            Price = price;
        }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int FromQuantity { get; set; }
        public int ToQuantity { get; set; }
        public decimal Price { get; set; }
    }
}