using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;

namespace core.Interfaces
{
    public interface IProductRepository
    {
       Task <IReadOnlyList<Product>>  getProducts();

       Task<Product>  getProduct(int id);
    }
}