using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq.Expressions;
using core.Entities;

namespace core.Specifications
{
    public class ProductWithBrandsAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandsAndTypeSpecification(SpecParams pams):base(
            x=>(string.IsNullOrEmpty(pams.Search)|| x.Name.Contains(pams.Search)) && 
            (!pams.BrandId.HasValue || x.ProductBrandId== pams.BrandId ) &&
            (!pams.TypeId.HasValue || x.ProductTypeId == pams.TypeId )
        )
        {

            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            AddOrderby(x => x.Name);
            AddPaging(pams.PageSize*(pams.PageIndex-1), pams.PageSize );

            if (!string.IsNullOrEmpty(pams.sort))
            {
                switch (pams.sort)
                {
                    case "PriceAsc":
                        AddOrderby(x => x.Price);
                        break;
                    case "PriceDesc":
                        AddOrderbyDesc(x => x.Price);
                        break;
                    default:
                        AddOrderby(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithBrandsAndTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }

        //       public ProductWithBrandsAndTypeSpecification(string input, string name) : base(x=> x.Equals(name) ==input)
        // {
        //     AddIncludes(x =>x.ProductBrand);
        //     AddIncludes(x =>x.ProductType);       }
    }
}