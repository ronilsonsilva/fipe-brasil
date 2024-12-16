using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Comment.Queries
{
    public class GetCommentByIdQuery : IRequest<CommentDto?>
    {
        public Guid Id { get; set; }
    }
}
