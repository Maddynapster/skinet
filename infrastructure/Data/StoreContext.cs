using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using core;
using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            base.OnModelCreating(mod);
            mod.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
  public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
      
    }
}