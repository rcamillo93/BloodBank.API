using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using BloodBank.Core.Services;
using MediatR;


namespace BloodBank.Application.Queries.ReportQueries.DonationsReport
{
    public class GetAllDonationsByPeriodReportQueryHandler : IRequestHandler<GetAllDonationsByPeriodReportQuery, byte[]>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IReportService _reportService;

        public GetAllDonationsByPeriodReportQueryHandler(IDonationRepository donationRepository, IReportService reportService)
        {
            _donationRepository = donationRepository;
            _reportService = reportService;
        }

        public async Task<byte[]> Handle(GetAllDonationsByPeriodReportQuery request, CancellationToken cancellationToken)
        {
            var reportData = await _donationRepository.GetAllByPeriod(request.StartDate, request.EndDate);

            var pdfBytes = _reportService.GenerateDonationsReport(reportData, request.StartDate, request.EndDate);

            return pdfBytes;
        }
    }
}
