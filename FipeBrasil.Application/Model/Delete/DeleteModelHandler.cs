using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Model.Delete
{
    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponse>
    {
        private readonly IRepository<Domain.Entities.Model> _modelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModelHandler(IRepository<Domain.Entities.Model> modelRepository, IUnitOfWork unitOfWork)
        {
            _modelRepository = modelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetByIdAsync(request.Id);
            if (model == null)
                throw new KeyNotFoundException("Model not found.");

            await _modelRepository.DeleteAsync(model.Id);
            await _unitOfWork.CommitAsync();
            return DeleteModelResponse.From(model);
        }
    }
}
