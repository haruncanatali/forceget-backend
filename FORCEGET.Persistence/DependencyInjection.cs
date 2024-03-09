using FORCEGET.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FORCEGET.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("MySQL"))
        );
        services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
        return services;
    }
}