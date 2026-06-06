using Microsoft.Extensions.DependencyInjection;

namespace SGRBuddy.BusinessLogic;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<SGRItemService>();

        return services;
    }
}