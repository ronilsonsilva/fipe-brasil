using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Queries
{
    public class GetVehicleYearByIdHandler : IRequestHandler<GetVehicleYearByIdQuery, VehicleYearDto?>
    {
        private readonly IRepository<Domain.Entities.VehicleYear> _vehicleYearRepository;

        public GetVehicleYearByIdHandler(IRepository<Domain.Entities.VehicleYear> vehicleYearRepository)
        {
            _vehicleYearRepository = vehicleYearRepository;
        }

        public async Task<VehicleYearDto?> Handle(GetVehicleYearByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleYear = await _vehicleYearRepository.GetByIdAsync(request.Id);
            return vehicleYear == null ? null : new VehicleYearDto
            {
                Id = vehicleYear.Id,
                Code = vehicleYear.Code,
                Name = vehicleYear.Name
            };
        }
    }
}
