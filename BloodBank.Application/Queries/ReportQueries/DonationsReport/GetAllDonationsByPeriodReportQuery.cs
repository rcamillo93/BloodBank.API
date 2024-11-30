using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.DonationsReport
{
    public class GetAllDonationsByPeriodReportQuery : IRequest<byte[]>
    {
        public GetAllDonationsByPeriodReportQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
