using FipeBrasil.Application.Vehicle.Create;
using FipeBrasil.Application.Vehicle.Delete;
using FipeBrasil.Application.Vehicle.Queries;
using FipeBrasil.Application.Vehicle.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FipeBrasil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteVehicleCommand { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetVehiclesQuery { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVehicleByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
