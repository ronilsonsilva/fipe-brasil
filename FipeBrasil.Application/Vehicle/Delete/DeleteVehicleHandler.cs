using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Delete
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, DeleteVehicleResponse>
    {
        private readonly IRepository<Domain.Entities.Vehicle> _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleHandler(IRepository<Domain.Entities.Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteVehicleResponse> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found.");

            await _vehicleRepository.DeleteAsync(vehicle.Id);
            await _unitOfWork.CommitAsync();
            return DeleteVehicleResponse.From(vehicle);
        }
    }
}
