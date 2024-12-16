using FipeBrasil.Application.VehicleYear.Create;
using FipeBrasil.Application.VehicleYear.Delete;
using FipeBrasil.Application.VehicleYear.Queries;
using FipeBrasil.Application.VehicleYear.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FipeBrasil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleYearController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleYearController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleYearCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleYearCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteVehicleYearCommand { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetVehicleYearsQuery { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVehicleYearByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
