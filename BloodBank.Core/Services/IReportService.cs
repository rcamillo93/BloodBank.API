using BloodBank.Core.Models;

namespace BloodBank.Core.Services
{
    public interface IReportService
    {
       byte[] GenerateStockReport(List<StockReportModel> data);
    }
}
