using BloodBank.Core.Entity;
using BloodBank.Core.Models;
using BloodBank.Core.Services;
using BloodBank.Infrastructure.Reports;
using QuestPDF.Fluent;

namespace BloodBank.Infrastructure.Service
{
    public class ReportService : IReportService
    {
        public byte[] GenerateDonationsReport(List<Donation> data, DateTime startDate, DateTime endDate)
        {
            var document = new DonationsReportDocument(data, startDate, endDate);
            return document.GeneratePdf();
        }

        public byte[] GenerateStockReport(List<StockReportModel> data)
        {
            var document = new StockReportDocument(data);
            return document.GeneratePdf();
        }
    }
}
