using Andy;
using Andy.Core.Interfaces;
using Andy.Core.Mappers;
using Andy.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Andy.Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<SubscriptionMapper>();
            services.AddScoped<ISubscitionService, SubscitionService>();

            return services;
        }
    }
}
