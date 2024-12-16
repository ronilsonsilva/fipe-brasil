using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Create
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleResponse>
    {
        private readonly IRepository<Domain.Entities.Vehicle> _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleHandler(IRepository<Domain.Entities.Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateVehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Domain.Entities.Vehicle(request.VehicleType, request.Price, request.BrandName, request.ModelName, request.ModelYear, request.FuelType, request.FipeCode, request.FuelAbbreviation, request.ReferenceMonth, request.ModelId);
            await _vehicleRepository.AddAsync(vehicle);
            await _unitOfWork.CommitAsync();
            return CreateVehicleResponse.From(vehicle);
        }
    }
}
