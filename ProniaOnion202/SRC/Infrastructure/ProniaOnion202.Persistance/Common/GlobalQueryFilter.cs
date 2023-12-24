using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Common
{
    internal static class GlobalQueryFilter
    {
        public static void ApplyFilter<T> (this ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(c=>c.IsDeleted==false);
        }
        public static void ApplyQueryFilters(this ModelBuilder builder)
        {
            builder.ApplyFilter<Product>();
            builder.ApplyFilter<Category>();
            builder.ApplyFilter<Color>();
            builder.ApplyFilter<Tag>();
            builder.ApplyFilter<ProductTag>();
            builder.ApplyFilter<ProductColor>();
        }
    }
}
