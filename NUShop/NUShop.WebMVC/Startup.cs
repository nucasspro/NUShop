﻿using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUShop.Data.EF;
using NUShop.Data.EF.Repositories;
using NUShop.Data.Entities;
using NUShop.Data.IRepositories;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Implements;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModelConfiguration;
using NUShop.Service.ViewModels;
using System;

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
                .AddFluentValidation();

            #region Dependency Injection for Fluent Validators

            services.AddTransient<IValidator<CategoryViewModel>, CategoryValidator>();

            #endregion Dependency Injection for Fluent Validators


            #region Configure Identity I

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

            #endregion Configure Identity I

            services.AddTransient<DbSeeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Dependency Injection for Repositories

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            #endregion Dependency Injection for Repositories

            #region Dependency Injection for Services

            services.AddTransient<ICategoryService, CategoryService>();

            #endregion Dependency Injection for Services

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            if (env.IsDevelopment())
            {
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
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}