using BloodBank.Core.Entity;
using BloodBank.Core.Models;

namespace BloodBank.Core.Services
{
    public interface IReportService
    {
       byte[] GenerateStockReport(List<StockReportModel> data);
       byte[] GenerateDonationsReport(List<Donation> data, DateTime startDate, DateTime endDate);
    }
}
