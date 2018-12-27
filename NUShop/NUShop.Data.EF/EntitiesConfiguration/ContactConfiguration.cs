using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ContactConfiguration : DbEntityConfiguration<Contact>

    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("ContactDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Phone).IsRequired(false).HasColumnName("Phone").HasColumnType("varchar(50)");
            builder.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("varchar(255)");
            builder.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("varchar(255)");
            builder.Property(x => x.Website).IsRequired(false).HasColumnName("Website").HasColumnType("varchar(255)");
            builder.Property(x => x.Address).IsRequired(false).HasColumnName("Address").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Other).IsRequired(false).HasColumnName("Other").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Lat).IsRequired(false).HasColumnName("Lat").HasColumnType("float");
            builder.Property(x => x.Lng).IsRequired(false).HasColumnName("Lng").HasColumnType("float");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}