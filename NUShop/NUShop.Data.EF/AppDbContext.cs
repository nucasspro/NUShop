using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NUShop.Data.EF.EntityConfigurations;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Data.Interfaces;
using System;
using System.Linq;

namespace NUShop.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    //public class AppDbContext : IdentityDbContext

    {
        private readonly IdentityDbContext DbContext;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Blog> Bills { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ProductQuantity> ProductQuantities { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Size> Sizes { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<WholePrice> WholePrices { get; set; }

        #endregion DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            //optionsBuilder.UseSqlServer(DbContext.Database.GetDbConnection());
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-9VB67KJ; Database = NUShop1; Trusted_Connection = True; ConnectRetryCount = 0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Add Entity Configurations

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            modelBuilder.AddConfiguration(new AdvertistmentConfiguration());
            modelBuilder.AddConfiguration(new AdvertistmentPageConfiguration());
            modelBuilder.AddConfiguration(new AdvertistmentPositionConfiguration());
            modelBuilder.AddConfiguration(new AnnouncementConfiguration());
            modelBuilder.AddConfiguration(new AnnouncementUserConfiguration());
            modelBuilder.AddConfiguration(new AppRoleConfiguration());
            modelBuilder.AddConfiguration(new AppUserConfiguration());
            modelBuilder.AddConfiguration(new BillConfiguration());
            modelBuilder.AddConfiguration(new BillDetailConfiguration());
            modelBuilder.AddConfiguration(new BlogConfiguration());
            modelBuilder.AddConfiguration(new BlogTagConfiguration());
            modelBuilder.AddConfiguration(new CategoryConfiguration());
            modelBuilder.AddConfiguration(new ColorConfiguration());
            modelBuilder.AddConfiguration(new ContactConfiguration());
            modelBuilder.AddConfiguration(new FeedbackConfiguration());
            modelBuilder.AddConfiguration(new FooterConfiguration());
            modelBuilder.AddConfiguration(new FunctionConfiguration());
            modelBuilder.AddConfiguration(new LanguageConfiguration());
            modelBuilder.AddConfiguration(new PageConfiguration());
            modelBuilder.AddConfiguration(new PermissionConfiguration());
            modelBuilder.AddConfiguration(new ProductConfiguration());
            modelBuilder.AddConfiguration(new ProductImageConfiguration());
            modelBuilder.AddConfiguration(new ProductQuantityConfiguration());
            modelBuilder.AddConfiguration(new ProductTagConfiguration());
            modelBuilder.AddConfiguration(new SizeConfiguration());
            modelBuilder.AddConfiguration(new SlideConfiguration());
            modelBuilder.AddConfiguration(new SystemConfigConfiguration());
            modelBuilder.AddConfiguration(new TagConfiguration());
            modelBuilder.AddConfiguration(new WholePriceConfiguration());

            #endregion Add Entity Configurations
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                IDateTracking changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}