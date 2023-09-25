using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;

namespace RepositoryLayer.DependencyInjections;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DataContext")));

        services.AddScoped<ISortingRepository, SortingRepository>();

        return services;
    }
}