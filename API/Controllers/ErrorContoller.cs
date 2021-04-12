
using API.Error;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("error/{errorCode}")]
    [ApiExplorerSettings(IgnoreApi=true)]
    public class ErrorContoller :BaseApiController
    {
        public IActionResult Error( int errorCode){

            return new ObjectResult(new ErrorResponse(errorCode));
        }
        
    }
}