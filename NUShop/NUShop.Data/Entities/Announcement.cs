using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Announcement : DomainEntity<string>, ISwitchable, IDateTracking
    {
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        public Announcement(string title, string content, Guid userId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            Status = Status.Active;
        }

        public string Title { set; get; }
        public string Content { set; get; }

        public Guid UserId { set; get; }
        public virtual AppUser AppUser { get; set; }

        public Status Status { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}