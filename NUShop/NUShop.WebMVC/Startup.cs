using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NUShop.Data.EF;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Implements;
using NUShop.Service.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Identity;
using NUShop.Data.Entities;
using NUShop.WebMVC.Extensions;
using Microsoft.AspNetCore.Authorization;
using NUShop.WebMVC.Authorization;

namespace NUShop.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddJsonOptions(opt => { opt.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            #region Dependency Injection for Fluent Validators

            //services.AddTransient<IValidator<CategoryViewModel>, CategoryValidator>();

            #endregion Dependency Injection for Fluent Validators

            #region Configure Identity

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            #endregion Configure Identity

            services.AddTransient<DbSeeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipal>();

            #region Dependency Injection for Services

            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();



            #endregion Dependency Injection for Services

            services.AddAutoMapper();
            services.AddTransient<IAuthorizationHandler, ResourceAuthorizationHandler>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                    RequestPath = new PathString("/node_modules")
                });

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "adminArea",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}