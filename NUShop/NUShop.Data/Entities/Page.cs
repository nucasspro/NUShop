using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Page : DomainEntity<int>, ISwitchable
    {
        public Page() { }

        public Page(int id, string name, string alias, string content, Status status)
        {
            Id = id;
            Name = name;
            Alias = alias;
            Content = content;
            Status = status;
        }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Content { set; get; }
        public Status Status { set; get; }
    }
}
