using NUShop.Infrastructure.Shared;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class AdvertistmentPage : DomainEntity<string>
    {
        public AdvertistmentPage()
        {
            AdvertistmentPositions = new List<AdvertistmentPosition>();
        }

        public string Name { get; set; }
        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}