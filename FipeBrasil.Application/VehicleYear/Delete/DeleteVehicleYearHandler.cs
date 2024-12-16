using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Delete
{
    public class DeleteVehicleYearHandler : IRequestHandler<DeleteVehicleYearCommand, DeleteVehicleYearResponse>
    {
        private readonly IRepository<Domain.Entities.VehicleYear> _vehicleYearRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleYearHandler(IRepository<Domain.Entities.VehicleYear> vehicleYearRepository, IUnitOfWork unitOfWork)
        {
            _vehicleYearRepository = vehicleYearRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteVehicleYearResponse> Handle(DeleteVehicleYearCommand request, CancellationToken cancellationToken)
        {
            var vehicleYear = await _vehicleYearRepository.GetByIdAsync(request.Id);
            if (vehicleYear == null)
                throw new KeyNotFoundException("VehicleYear not found.");

            await _vehicleYearRepository.DeleteAsync(vehicleYear.Id);
            await _unitOfWork.CommitAsync();
            return DeleteVehicleYearResponse.From(vehicleYear);
        }
    }
}
