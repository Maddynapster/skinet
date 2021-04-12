using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.MiddleWare
{
    public class ExceptionMiddlerware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlerware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddlerware(RequestDelegate next, ILogger<ExceptionMiddlerware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;

        }

        public async Task InvokeAsync(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                http.Response.ContentType = "application/json";
                http.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var res = _env.IsDevelopment() ? new ErrorException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                                new ErrorException((int)HttpStatusCode.InternalServerError);

var option =  new JsonSerializerOptions{PropertyNamingPolicy= JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(res, option);
            }
        }
    }
}