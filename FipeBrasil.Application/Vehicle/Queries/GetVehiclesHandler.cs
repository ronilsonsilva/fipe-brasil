using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Queries
{
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleDto>>
    {
        private readonly IRepository<Domain.Entities.Vehicle> _vehicleRepository;

        public GetVehiclesHandler(IRepository<Domain.Entities.Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return vehicles
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(v => new VehicleDto
                {
                    Id = v.Id,
                    BrandName = v.BrandName,
                    ModelName = v.ModelName,
                    Price = v.Price,
                    ModelYear = v.ModelYear,
                    FuelType = v.FuelType
                });
        }
    }
}
