using core.Entities;

namespace core.Specifications
{
    public class ProductWithFilterSpecification: BaseSpecification<Product>
    {
      public ProductWithFilterSpecification (SpecParams pams): base(
            x=> (string.IsNullOrEmpty(pams.Search)|| x.Name.Contains(pams.Search)) && 
            (!pams.BrandId.HasValue || x.ProductBrandId== pams.BrandId ) &&
            (!pams.TypeId.HasValue || x.ProductTypeId == pams.TypeId )
        )
      {
          
      } 
    }
}