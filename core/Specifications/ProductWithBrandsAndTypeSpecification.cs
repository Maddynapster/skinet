using System;
using System.Linq.Expressions;
using core.Entities;

namespace core.Specifications
{
    public class ProductWithBrandsAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandsAndTypeSpecification()
        {
            AddIncludes(x =>x.ProductBrand);
            AddIncludes(x =>x.ProductType);
        }

        public ProductWithBrandsAndTypeSpecification(int id) : base(x=> x.Id==id)
        {
            AddIncludes(x =>x.ProductBrand);
            AddIncludes(x =>x.ProductType);       }

        //       public ProductWithBrandsAndTypeSpecification(string input, string name) : base(x=> x.Equals(name) ==input)
        // {
        //     AddIncludes(x =>x.ProductBrand);
        //     AddIncludes(x =>x.ProductType);       }
    }
}