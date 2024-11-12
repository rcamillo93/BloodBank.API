using BloodBank.Application.Commands.DonationComands;
using BloodBank.Application.Commands.DonorComands.CreateDonor;
using BloodBank.Application.Commands.DonorComands.UpdateDonor;
using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using BloodBank.Core.Services;
using BloodBank.Infrastructure.ExternalApi;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using BloodBank.Infrastructure.Service;
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
                .AddRepositories(configuration)
                .AddServices(configuration);                              

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloodBankDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("BloodBank")));

            services.AddScoped<IDonorRepository, DonorRepository>();   
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>());

            services.AddTransient<IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>, ValidateCreateDonationCommandBehavior>();

            services.AddTransient<IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>, ValidateCreateDonorCommandBehavior>();

            services.AddTransient<IPipelineBehavior<UpdateDonorCommand, ResultViewModel>, ValidateUpdateDonorCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICepService, CepService>();
            services.AddScoped<IReportService, ReportService>();

            return services;
        }
    }
}
