using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.ReportQueries.DonationsReport
{
    public class GetAllDonationsByPeriodReportQueryHandler : IRequestHandler<GetAllDonationsByPeriodReportQuery, byte[]>
    {
        private readonly IDonationRepository _donationRepository;

        public Task<byte[]> Handle(GetAllDonationsByPeriodReportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
