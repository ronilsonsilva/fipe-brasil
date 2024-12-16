using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Comment.Delete
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentHandler(IRepository<Domain.Entities.Comment> commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found.");

            await _commentRepository.DeleteAsync(comment.Id);
            await _unitOfWork.CommitAsync();
            return DeleteCommentResponse.From(comment);
        }
    }
}
