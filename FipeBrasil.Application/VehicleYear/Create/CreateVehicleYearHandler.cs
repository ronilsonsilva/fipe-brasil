using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Create
{
    // Handlers for VehicleYear
    public class CreateVehicleYearHandler : IRequestHandler<CreateVehicleYearCommand, CreateVehicleYearResponse>
    {
        private readonly IRepository<Domain.Entities.VehicleYear> _vehicleYearRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleYearHandler(IRepository<Domain.Entities.VehicleYear> vehicleYearRepository, IUnitOfWork unitOfWork)
        {
            _vehicleYearRepository = vehicleYearRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateVehicleYearResponse> Handle(CreateVehicleYearCommand request, CancellationToken cancellationToken)
        {
            var vehicleYear = new Domain.Entities.VehicleYear(request.Code, request.Name, request.ModelId);
            await _vehicleYearRepository.AddAsync(vehicleYear);
            await _unitOfWork.CommitAsync();
            return CreateVehicleYearResponse.From(vehicleYear);
        }
    }
}
