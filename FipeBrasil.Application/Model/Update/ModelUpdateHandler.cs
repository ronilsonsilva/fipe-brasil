using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Model.Update
{
    public class ModelUpdateHandler : IRequestHandler<UpdateModelCommand, ModelUpdateResponse>
    {
        private readonly IRepository<Domain.Entities.Model> _modelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ModelUpdateHandler(IRepository<Domain.Entities.Model> modelRepository, IUnitOfWork unitOfWork)
        {
            _modelRepository = modelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ModelUpdateResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetByIdAsync(request.Id);
            if (model == null)
                throw new KeyNotFoundException("Model not found.");

            model.SetCode(request.Code)
                .SetName(request.Name);
            await _modelRepository.UpdateAsync(model);
            await _unitOfWork.CommitAsync();
            return ModelUpdateResponse.From(model);
        }
    }
}
