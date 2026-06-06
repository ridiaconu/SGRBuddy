using Microsoft.Extensions.DependencyInjection;
using SGRBuddy.DataAccess.Repositories;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace SGRBuddy.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SGRContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ISGRItemRepository, SGRItemRepository>();
        services.AddScoped<ISGRSessionRepository, SGRSessionRepository>();

        return services;
    }
}