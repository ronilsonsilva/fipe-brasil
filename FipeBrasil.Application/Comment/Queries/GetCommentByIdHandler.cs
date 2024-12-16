using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Comment.Queries
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;

        public GetCommentByIdHandler(IRepository<Domain.Entities.Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            return comment == null ? null : new CommentDto
            {
                Id = comment.Id,
                AuthorName = comment.AuthorName,
                AuthorEmail = comment.AuthorEmail,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt
            };
        }
    }
}
