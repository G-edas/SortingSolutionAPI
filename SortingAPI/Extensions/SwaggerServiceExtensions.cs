using Microsoft.OpenApi.Models;

namespace SortingAPI.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services, IConfiguration c)
        {

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API", Version = "v1" });
                }
            );

            return services;

        }
    }
}
