using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Comment.Queries
{
    public class GetCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
