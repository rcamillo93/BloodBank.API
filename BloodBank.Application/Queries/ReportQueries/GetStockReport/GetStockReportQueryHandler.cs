using BloodBank.Core.Repositories;
using BloodBank.Core.Services;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.GetStockReport
{
    public class GetStockReportQueryHandler : IRequestHandler<GetStockReportQuery, byte[]>
    {
        private readonly IReportService _reportService;
        private readonly IBloodStockRepository _stockRepository;

        public GetStockReportQueryHandler(IReportService reportService, IBloodStockRepository stockRepository)
        {
            _reportService = reportService;
            _stockRepository = stockRepository;
        }

        public async Task<byte[]> Handle(GetStockReportQuery request, CancellationToken cancellationToken)
        {
            var reportData = await _stockRepository.GetStockReportAsync();

            var pdfBytes = _reportService.GenerateStockReport(reportData);

            return pdfBytes;
        }
    }
}
