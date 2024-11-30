using BloodBank.Application.Queries.ReportQueries.DonationsReport;
using BloodBank.Application.Queries.ReportQueries.GetStockReport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("stockreport")]
        public async Task<IActionResult> GetStockReport()
        {
            var query = new GetStockReportQuery();

            var result = await _mediator.Send(query);

            return File(result, "application/pdf", $"StockReport-{DateTime.Now.ToShortDateString()}.pdf");
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetDonationsReport([FromQuery] DateTime startDate, DateTime endDate)
        {
            var query = new GetAllDonationsByPeriodReportQuery(startDate, endDate);

            var result = await _mediator.Send(query);

            return File(result, "application/pdf", $"DonationsReport-{DateTime.Now.ToShortDateString()}.pdf");
        }
    }
}
