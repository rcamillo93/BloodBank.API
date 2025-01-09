using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRatingManager.Application
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHandlers()
                .AddRepositories(configuration)
                .AddServices(configuration);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

    }
}
