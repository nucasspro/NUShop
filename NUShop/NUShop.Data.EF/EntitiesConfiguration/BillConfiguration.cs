using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Data.Enums;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class BillConfiguration : DbEntityConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.CustomerName).IsRequired(true).HasColumnName("CustomerName").HasColumnType("nvarchar(255)");
            builder.Property(x => x.CustomerAddress).IsRequired(true).HasColumnName("CustomerAddress").HasColumnType("nvarchar(255)");
            builder.Property(x => x.CustomerMobile).IsRequired(true).HasColumnName("CustomerMobile").HasColumnType("nvarchar(255)");
            builder.Property(x => x.CustomerMessage).IsRequired(true).HasColumnName("CustomerMessage").HasColumnType("nvarchar(255)");
            builder.Property(x => x.PaymentMethod).IsRequired(true).HasColumnName("PaymentMethod").HasColumnType("int");
            builder.Property(x => x.BillStatus).IsRequired(true).HasColumnName("BillStatus").HasColumnType("int");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int").HasDefaultValue(Status.Active);
            builder.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("datetime");

            builder.Property(x => x.CustomerId).IsRequired(false).HasColumnName("CustomerId").HasColumnType("uniqueidentifier");
            builder.HasOne(x => x.User).WithMany(y => y.Bills).HasForeignKey(z => z.CustomerId);
        }
    }
}