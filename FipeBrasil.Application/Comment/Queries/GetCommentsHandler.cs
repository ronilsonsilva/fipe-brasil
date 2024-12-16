using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Comment.Queries
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;

        public GetCommentsHandler(IRepository<Domain.Entities.Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllAsync();
            return comments
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    AuthorName = c.AuthorName,
                    AuthorEmail = c.AuthorEmail,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt
                });
        }
    }
}
