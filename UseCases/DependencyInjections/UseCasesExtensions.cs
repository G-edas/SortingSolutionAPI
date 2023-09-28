using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCases;
using UseCases.Interfaces;

namespace BusinessLayer.DependencyInjections;

public static class UseCasesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ISortingUseCase, SortingUseCase>();
        services.AddScoped<IGetContentUseCase, GetContentUseCase>();
        services.AddScoped<ITimeBetweenMultipleSortingUseCase, TimeBetweenMultipleSortingUseCase>();

        return services;
    }
}