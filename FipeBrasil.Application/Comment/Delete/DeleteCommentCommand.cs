using MediatR;

namespace FipeBrasil.Application.Comment.Delete
{
    public class DeleteCommentCommand : IRequest<DeleteCommentResponse>
    {
        public Guid Id { get; set; }
    }
}
