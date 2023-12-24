using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Domain.Entities;
using ProniaOnion202.Persistance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyQueryFilters();    

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly .GetExecutingAssembly());       
            base.OnModelCreating(modelBuilder); 
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Category>();
           

            foreach (var data in entries) {
                switch (data.State)
                {
                    
                    case EntityState.Modified:
                        data.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.Now;

                        break;
                }
            }
            var entries2 = ChangeTracker.Entries<Tag>();


            foreach (var data in entries2)
            {
                switch (data.State)
                {

                    case EntityState.Modified:
                        data.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.Now;

                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
