using NUShop.Infrastructure.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUShop.Data.Entities
{
    [Table("WholePrices")]
    public class WholePrice : DomainEntity<int>
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int FromQuantity { get; set; }
        public int ToQuantity { get; set; }
        public decimal Price { get; set; }
    }
}