using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Error;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{


    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper __mapper;
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> ProductBrandRepo,
        

        IGenericRepository<ProductType> ProductTypeRepo, IMapper _mapper)
        {
            __mapper = _mapper;
            _ProductTypeRepo = ProductTypeRepo;
            _ProductBrandRepo = ProductBrandRepo;
            _productRepo = productRepo;



        }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        var spec = new ProductWithBrandsAndTypeSpecification();
        return Ok(await _productRepo.ListAsync(spec));
    }
    [HttpGet("{id}")]
    [ProducesDefaultResponseType(typeof(ErrorResponse))]
    
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductWithBrandsAndTypeSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        if (product == null) return NotFound(new ErrorResponse(404));

        return __mapper.Map<Product, ProductToReturnDto>(product);
    }
}
}