using FipeBrasil.Application.Brand.Create;
using FipeBrasil.Application.Brand.Delete;
using FipeBrasil.Application.Brand.Queries;
using FipeBrasil.Application.Brand.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FipeBrasil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBrandCommand { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetBrandsQuery { Page = page, PageSize = pageSize });
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
