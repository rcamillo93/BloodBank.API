
using BloodBank.Application.Models;
using BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStock;
using BloodBank.Application.Queries.ReportQueries.GetStockReport;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Services;
using MediatR;

namespace BloodBank.API.HostedService
{
    public class BloodStockControl : IHostedService
    {
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private string _emailNotification;

        public BloodStockControl(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _emailNotification = _configuration["EmailNotification"];         
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckBloodStock, null, 0, 14400000);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async void CheckBloodStock(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var stockQueryHandler = scope.ServiceProvider.GetRequiredService<IRequestHandler<GetAllBloodStockQuery, ResultViewModel<List<BloodStockViewModel>>>>();
                
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
    
                var stockResult = await stockQueryHandler.Handle(new GetAllBloodStockQuery(), CancellationToken.None);

                if (!stockResult.IsSuccess || stockResult.Data == null) return;
               
                var lowStock = stockResult.Data.Where(s => s.QuantityMl < 1260).ToList();

                if (lowStock.Any())
                {
                    var reportQueryHandler = scope.ServiceProvider.GetRequiredService<IRequestHandler<GetStockReportQuery, byte[]>>();

                    var reportBytes = await reportQueryHandler.Handle(new GetStockReportQuery(), CancellationToken.None);
                                        
                    var subject = "Alerta: Estoque de Sangue Baixo";
                    var content = "Segue em anexo o relatório do estoque de sangue atual.";                   
                    var toName = "Administração Banco de Sangue";
                                        
                    await emailService.SendEmailAsync(subject, content, _emailNotification, toName, reportBytes, "EstoqueDeSangue.pdf");
                }
            }
        }
    }
}
