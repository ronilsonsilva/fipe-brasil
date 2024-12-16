using FipeBrasil.Application.Model.Create;
using FipeBrasil.Application.Model.Delete;
using FipeBrasil.Application.Model.Queries;
using FipeBrasil.Application.Model.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FipeBrasil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModelCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteModelCommand { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetModelsQuery { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetModelByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
