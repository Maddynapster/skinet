using System.Linq;
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

            if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite"){
                foreach (var item in mod.Model.GetEntityTypes())
                {
                    var prop= item.ClrType.GetProperties().Where(p => p.PropertyType== typeof(decimal));
                     foreach (var property in prop)
                     {
                         mod.Entity(item.Name).Property(property.Name).HasConversion<double>();
                     }
                }
            }
        }
  public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
      
    }
}