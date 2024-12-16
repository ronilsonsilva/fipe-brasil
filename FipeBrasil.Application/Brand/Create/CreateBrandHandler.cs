using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Brand.Create
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandHandler(IRepository<Domain.Entities.Brand> brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Domain.Entities.Brand(request.Code, request.Name);
            await _brandRepository.AddAsync(brand);
            await _unitOfWork.CommitAsync();
            return CreateBrandResponse.From(brand);
        }
    }
}
