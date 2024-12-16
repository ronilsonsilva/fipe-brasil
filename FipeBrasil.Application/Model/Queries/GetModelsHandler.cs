using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Model.Queries
{
    public class GetModelsHandler : IRequestHandler<GetModelsQuery, IEnumerable<ModelDto>>
    {
        private readonly IRepository<Domain.Entities.Model> _modelRepository;

        public GetModelsHandler(IRepository<Domain.Entities.Model> modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<IEnumerable<ModelDto>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetAllAsync();
            return models
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(m => new ModelDto { Id = m.Id, Code = m.Code, Name = m.Name });
        }
    }
}
