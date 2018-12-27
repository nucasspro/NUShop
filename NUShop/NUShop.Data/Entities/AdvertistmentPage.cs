
using NUShop.Infrastructure.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUShop.Data.Entities
{
    public class AdvertistmentPage : DomainEntity<string>
    {
        public string Name { get; set; }
        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}