using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NUShop.Data.EF;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Implements;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModelConfiguration;
using NUShop.Service.ViewModels;
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddJsonOptions(opt => { opt.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            #region Dependency Injection for Fluent Validators

            services.AddTransient<IValidator<CategoryViewModel>, CategoryValidator>();

            #endregion Dependency Injection for Fluent Validators

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region Configure Identity I

            //services
            //    .AddIdentity<AppUser, AppRole>()
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddDefaultTokenProviders();

            //// Configure Identity
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 2;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //    options.Lockout.MaxFailedAccessAttempts = 10;

            //    // User settings
            //    options.User.RequireUniqueEmail = true;
            //});
            //services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            //services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            #endregion Configure Identity I

            //services.AddTransient<DbSeeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Dependency Injection for Repositories

            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IFunctionRepository, FunctionRepository>();
            //services.AddTransient<Iproducre, FunctionRepository>();
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            #endregion Dependency Injection for Repositories

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
                    builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
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