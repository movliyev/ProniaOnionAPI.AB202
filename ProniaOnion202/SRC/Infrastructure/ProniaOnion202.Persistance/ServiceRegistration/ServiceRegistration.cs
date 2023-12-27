using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Domain.Entities;
using ProniaOnion202.Persistance.DAL;
using ProniaOnion202.Persistance.Implementations.Repositories;
using ProniaOnion202.Persistance.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration conf)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conf.GetConnectionString("Default"),
                b=>b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.AllowedForNewUsers = true;

                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IUserService, UserService>();

            return services;

        }
    }
}
