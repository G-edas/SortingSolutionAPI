using BusinessLayer.DependencyInjections;
using Microsoft.OpenApi.Models;
namespace SortingAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();


            services.AddEndpointsApiExplorer()
                .AddSwaggerExtensions(config);

            services.AddBusinessServices(config);
            services.AddUseCases(config);

     
            return services;
        }
    }
}
