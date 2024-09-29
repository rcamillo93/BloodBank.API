using BloodBank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Application
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services 
                .AddRepositories(configuration);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloodBankDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("BloodBank")));                   

            return services;
        }
    }
}
