using System.Linq;
using System.Runtime.CompilerServices;
using API.Error;
using core.Interfaces;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
    public  static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services ){
        services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
              services.Configure<ApiBehaviorOptions>(option =>
             {
                option.InvalidModelStateResponseFactory = actionContext => 
                {
                
                var errors = actionContext.ModelState
                .Where(x=> x.Value.Errors.Count>0)
                .SelectMany(x=> x.Value.Errors)
                .Select(x=>x.ErrorMessage).ToArray();

                    var errorReaponse= new ValidationErrorResponse{
                        Errors=errors
                    };
                    return new BadRequestObjectResult(errorReaponse);
                };

            }            );

            return services;
        }
    }
}