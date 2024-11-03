using BloodBank.Application.Commands.BloodStockCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> PutBloodStock(OutputBloodStockCommand output)
        {
            var result = await _mediator.Send(output);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.IsSuccess);
        }
    }
}
