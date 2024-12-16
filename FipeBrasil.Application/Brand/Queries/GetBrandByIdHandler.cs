using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Brand.Queries
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, BrandDto?>
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;

        public GetBrandByIdHandler(IRepository<Domain.Entities.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id);
            return brand == null ? null : new BrandDto { Id = brand.Id, Code = brand.Code, Name = brand.Name };
        }
    }
}
