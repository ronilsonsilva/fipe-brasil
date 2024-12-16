using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Update
{
    public class UpdateVehicleYearHandler : IRequestHandler<UpdateVehicleYearCommand, UpdateVehicleYearResponse>
    {
        private readonly IRepository<Domain.Entities.VehicleYear> _vehicleYearRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVehicleYearHandler(IRepository<Domain.Entities.VehicleYear> vehicleYearRepository, IUnitOfWork unitOfWork)
        {
            _vehicleYearRepository = vehicleYearRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateVehicleYearResponse> Handle(UpdateVehicleYearCommand request, CancellationToken cancellationToken)
        {
            var vehicleYear = await _vehicleYearRepository.GetByIdAsync(request.Id);
            if (vehicleYear == null)
                throw new KeyNotFoundException("VehicleYear not found.");

            vehicleYear.SetCode(request.Code).SetName(request.Name);
            await _vehicleYearRepository.UpdateAsync(vehicleYear);
            await _unitOfWork.CommitAsync();
            return UpdateVehicleYearResponse.From(vehicleYear);
        }
    }
}
