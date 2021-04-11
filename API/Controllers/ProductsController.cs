using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts(){return "hello";}

    }
}