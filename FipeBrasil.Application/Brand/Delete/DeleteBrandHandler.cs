using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Brand.Delete
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandHandler(IRepository<Domain.Entities.Brand> brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id);
            if (brand == null)
                throw new KeyNotFoundException("Brand not found.");

            await _brandRepository.DeleteAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return DeleteBrandResponse.From(brand);
        }
    }
}
