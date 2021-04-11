using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<Product> getProduct(int id)
        {
            return await _context.Products.
            Include(p=> p.ProductBrand).
            Include(p=> p.ProductType).
            FirstOrDefaultAsync(p=> p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> getProducts()
        {
            return (IReadOnlyList<Product>)await _context.Products.
            Include(p=> p.ProductBrand).
            Include(p=> p.ProductType).
            ToListAsync();
        }
    }
}