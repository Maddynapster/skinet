using System;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using core.Entities;
using System.Collections.Generic;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach (var item in brand)
                    {
                        context.ProductBrands.Add(item);

                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var brandData = File.ReadAllText("../infrastructure/Data/SeedData/types.json");
                    var brand = JsonSerializer.Deserialize<List<ProductType>>(brandData);
                    foreach (var item in brand)
                    {
                        context.ProductTypes.Add(item);

                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var brandData = File.ReadAllText("../infrastructure/Data/SeedData/products.json");
                    var brand = JsonSerializer.Deserialize<List<Product>>(brandData);
                    foreach (var item in brand)
                    {
                        context.Products.Add(item);

                    }
                    await context.SaveChangesAsync();
                }


            }
            catch(Exception ex){
                 var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                   logger.LogError(ex, ex.Message );
            }
        }
    }
}