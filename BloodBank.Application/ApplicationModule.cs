using BloodBank.Application.Commands.DonorComands.CreateDonor;
using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using MediatR;
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
                .AddHandlers() 
                .AddRepositories(configuration);                              

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloodBankDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("BloodBank")));

            services.AddScoped<IDonorRepository, DonorRepository>();           

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>());

            return services;
        }
    }
}
