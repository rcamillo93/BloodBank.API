using BloodBank.Core.Models;
using BloodBank.Core.Services;
using BloodBank.Infrastructure.Reports;
using QuestPDF.Fluent;

namespace BloodBank.Infrastructure.Service
{
    public class ReportService : IReportService
    {
        public byte[] GenerateStockReport(List<StockReportModel> data)
        {
            var document = new StockReportDocument(data);
            return document.GeneratePdf();
        }
    }
}
