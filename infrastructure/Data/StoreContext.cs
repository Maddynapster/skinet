using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using core;

using Microsoft.EntityFrameworkCore;
    
namespace infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Product> Products { get; set; }
    }
}