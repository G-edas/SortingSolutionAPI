using BusinessLayer.BusinessServices;
using BusinessLayer.BusinessServices.SortingServices;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DependencyInjections;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration config)
    {

        services.AddScoped<ISortingServices, SortingServices>();
        services.AddScoped<IGetContentService, GetContentService>();
        services.AddScoped<ISaveContentService, SaveContentService>();

        return services;
    }
}