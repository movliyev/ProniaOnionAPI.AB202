using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Persistance.DAL;
using ProniaOnion202.Persistance.Implementations.Repositories;
using ProniaOnion202.Persistance.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration conf)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conf.GetConnectionString("Default")));
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();
            return services;

        }
    }
}
