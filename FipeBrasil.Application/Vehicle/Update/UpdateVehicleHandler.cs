using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Update
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleResponse>
    {
        private readonly IRepository<Domain.Entities.Vehicle> _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVehicleHandler(IRepository<Domain.Entities.Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateVehicleResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found.");

            vehicle.SetBrandName(request.BrandName)
                .SetModelName(request.ModelName)
                .SetPrice(request.Price)
                .SetModelYear(request.ModelYear)
                .SetFuelType(request.FuelType);

            await _vehicleRepository.UpdateAsync(vehicle);
            await _unitOfWork.CommitAsync();
            return UpdateVehicleResponse.From(vehicle);
        }
    }
}
