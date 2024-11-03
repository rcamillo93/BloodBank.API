using BloodBank.Application.Commands.DonorComands.CreateDonor;
using BloodBank.Application.Commands.DonorComands.UpdateDonor;
using BloodBank.Application.Queries.AddressQueries;
using BloodBank.Application.Queries.DonorQueries.GetAllDonors;
using BloodBank.Application.Queries.DonorQueries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {
            var query = new GetAllDonorsQuery();

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var query = new GetDonorByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetDonorById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateDonorCommand command)
        {
            var updateCommand = new UpdateDonorCommand(command.Id, command.FullName, command.Email, command.Weight,
                                                        command.BloodType, command.RhFactor, command.Address);

            var result = await _mediator.Send(updateCommand);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpGet("cep")]
        public async Task<IActionResult> GetAddressByCep(string cep)
        {
            var query = new GetAddressByCepQuery(cep);
            
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
