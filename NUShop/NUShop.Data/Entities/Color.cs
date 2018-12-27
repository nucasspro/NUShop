using NUShop.Infrastructure.Shared;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Color : DomainEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }

    }
}