using BloodBank.Application.Commands.DonationComands;
using BloodBank.Application.Queries.DonationQueries.GetAllByPeriod;
using BloodBank.Application.Queries.DonationQueries.GetByDonor;
using BloodBank.Application.Queries.DonationQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetDonationById), new { id = result.Data }, command);
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetAllByPeriod([FromQuery] DateTime initialDate, DateTime finishDate)
        {
            var query = new GetAllDonationsByPeriodQuery(initialDate, finishDate);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationById(int id)
        {
            var query = new GetDonationByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("bydonor/{idDonor}")]
        public async Task<IActionResult> GetDonationByDonor(int idDonor)
        {
            var query = new GetDonationByDonorQuery(idDonor);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
