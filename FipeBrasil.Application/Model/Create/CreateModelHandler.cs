using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Model.Create
{
    public class CreateModelHandler : IRequestHandler<CreateModelCommand, CreateModelResponse>
    {
        private readonly IRepository<Domain.Entities.Model> _modelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModelHandler(IRepository<Domain.Entities.Model> modelRepository, IUnitOfWork unitOfWork)
        {
            _modelRepository = modelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Entities.Model(request.Code, request.Name,request.BrandId);
            await _modelRepository.AddAsync(model);
            await _unitOfWork.CommitAsync();
            return CreateModelResponse.From(model);
        }
    }
}
