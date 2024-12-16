using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Comment.Update
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentHandler(IRepository<Domain.Entities.Comment> commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found.");

            comment.SetText(request.Text);
            await _commentRepository.UpdateAsync(comment);
            await _unitOfWork.CommitAsync();
            return UpdateCommentResponse.From(comment);
        }
    }
}
