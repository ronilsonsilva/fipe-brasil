using MediatR;

namespace FipeBrasil.Application.Comment.Create
{
    public class CreateCommentCommand : IRequest<CreateCommentResponse>
    {
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public Guid VehicleId { get; set; }
    }
}
