using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Brand.Queries
{
    public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, GetBrandsQueryResult>
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;

        public GetBrandsHandler(IRepository<Domain.Entities.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<GetBrandsQueryResult> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandsQuery = await _brandRepository.GetAllAsync();
            int count = brandsQuery.Count();
            var brands= brandsQuery
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(b => new BrandDto { Id = b.Id, Code = b.Code, Name = b.Name });
            return new GetBrandsQueryResult(brands, count);
        }
    }
}
