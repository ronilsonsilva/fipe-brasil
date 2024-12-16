using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Queries
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto?>
    {
        private readonly IRepository<Domain.Entities.Vehicle> _vehicleRepository;

        public GetVehicleByIdHandler(IRepository<Domain.Entities.Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto?> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
            return vehicle == null ? null : new VehicleDto
            {
                Id = vehicle.Id,
                BrandName = vehicle.BrandName,
                ModelName = vehicle.ModelName,
                Price = vehicle.Price,
                ModelYear = vehicle.ModelYear,
                FuelType = vehicle.FuelType
            };
        }
    }
}
