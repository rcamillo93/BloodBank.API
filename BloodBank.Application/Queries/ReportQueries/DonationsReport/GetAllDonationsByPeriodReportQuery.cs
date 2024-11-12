using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.DonationsReport
{
    public class GetAllDonationsByPeriodReportQuery : IRequest<byte[]>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
