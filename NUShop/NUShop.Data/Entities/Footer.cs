using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Footer : DomainEntity<string>
    {
        public string Content { set; get; }
    }
}
