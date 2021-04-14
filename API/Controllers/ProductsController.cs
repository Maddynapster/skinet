using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Error;
using API.Helpers;
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
    [HttpPost]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]SpecParams param)
    {
        var spec = new ProductWithBrandsAndTypeSpecification( param);
        var countSpec = new ProductWithFilterSpecification(param);
        var totalItems = await _productRepo.Count(countSpec); 
        var products = await _productRepo.ListAsync(spec);
         var data = __mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        return Ok( new Pagination<ProductToReturnDto>(param.PageIndex,param.PageSize,totalItems,data ));
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