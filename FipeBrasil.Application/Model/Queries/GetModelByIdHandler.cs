using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Model.Queries
{
    public class GetModelByIdHandler : IRequestHandler<GetModelByIdQuery, ModelDto?>
    {
        private readonly IRepository<Domain.Entities.Model> _modelRepository;

        public GetModelByIdHandler(IRepository<Domain.Entities.Model> modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<ModelDto?> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetByIdAsync(request.Id);
            return model == null ? null : new ModelDto { Id = model.Id, Code = model.Code, Name = model.Name };
        }
    }
}
