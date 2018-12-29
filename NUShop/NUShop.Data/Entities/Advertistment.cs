using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;

namespace NUShop.Data.Entities
{
    public class Advertistment : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        public Advertistment(string name, string description, string image,
            string url, string positionId, int sortOrder, string dateCreated, string dateModified)
        {
            Name = name;
            Description = description;
            Image = image;
            Url = url;
            PositionId = positionId;
            Status = Status.Active;
            SortOrder = sortOrder;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }

        public string PositionId { get; set; }
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }

        public Status Status { set; get; }
        public int SortOrder { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
    }
}