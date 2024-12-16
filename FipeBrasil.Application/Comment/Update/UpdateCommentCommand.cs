using MediatR;

namespace FipeBrasil.Application.Comment.Update
{
    public class UpdateCommentCommand : IRequest<UpdateCommentResponse>
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
