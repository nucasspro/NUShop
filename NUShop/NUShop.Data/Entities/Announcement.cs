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

        public Announcement(string title, string content, Guid userId, Status status)
        {
            Title = title;
            Content = content;
            UserId = userId;
            Status = status;
        }

        public string Title { set; get; }
        public string Content { set; get; }

        public Guid UserId { set; get; }
        public virtual AppUser AppUser { get; set; }

        public Status Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}