using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NUShop.Data.EF;
using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Helpers;
using NUShop.Service.Implements;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModelConfiguration;
using NUShop.ViewModel.ViewModels;
using Swashbuckle.AspNetCore.Swagger;

namespace NUShop.WebAPI
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

            services.AddTransient<IValidator<CategoryViewModel>, CategoryValidator>();

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

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();

            #endregion Dependency Injection for Services

            services.AddAutoMapper();

            #region Swagger

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Core API", Description = "Swagger Core API" });
                }
                );

            #endregion Swagger

            #region Cors

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

                options.AddPolicy("Localhost",
                    builder => builder.WithOrigins("https://localhost:5001","http://localhost:5000").AllowAnyHeader().AllowAnyMethod());
            });

            services.AddCors();

            #endregion Cors
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API"); });
            app.UseCors("AllowAllOrigin");
            app.UseMvc();
        }
    }
}