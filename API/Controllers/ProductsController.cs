using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts() { 
            return Ok( await _productRepo.getProducts()) ;
         }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) { 
            return await _productRepo.getProduct(id);
         }
    }
}