using NUShop.Infrastructure.Shared;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class AdvertistmentPosition : DomainEntity<string>
    {
        public string Name { get; set; }

        public string PageId { get; set; }
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }

        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}