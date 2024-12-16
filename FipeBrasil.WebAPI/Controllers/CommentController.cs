using FipeBrasil.Application.Comment.Create;
using FipeBrasil.Application.Comment.Delete;
using FipeBrasil.Application.Comment.Queries;
using FipeBrasil.Application.Comment.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FipeBrasil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCommentCommand { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetCommentsQuery { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCommentByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
