using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Brand.Update
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandHandler(IRepository<Domain.Entities.Brand> brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id);
            if (brand == null)
                throw new KeyNotFoundException("Brand not found.");

            brand.SetCode(request.Code).SetName(request.Name);
            await _brandRepository.UpdateAsync(brand);
            await _unitOfWork.CommitAsync();
            return UpdateBrandResponse.From(brand);
        }
    }
}
