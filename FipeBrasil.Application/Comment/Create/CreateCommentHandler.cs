using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Comment.Create
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentHandler(IRepository<Domain.Entities.Comment> commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Domain.Entities.Comment(request.AuthorName, request.AuthorEmail, request.Text, request.VehicleId);
            await _commentRepository.AddAsync(comment);
            await _unitOfWork.CommitAsync();
            return CreateCommentResponse.From(comment);
        }
    }
}
