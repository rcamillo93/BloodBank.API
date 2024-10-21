using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetAllByPeriod
{
    public class GetAllDonationsByPeriodQuery : IRequest<ResultViewModel<List<DonationViewModel>>>
    {
        public GetAllDonationsByPeriodQuery(DateTime initialDate, DateTime finishDate)
        {
            InitialDate = initialDate;
            FinishDate = finishDate;
        }

        public DateTime InitialDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
