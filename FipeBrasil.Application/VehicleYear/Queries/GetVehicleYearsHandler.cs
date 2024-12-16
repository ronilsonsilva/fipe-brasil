using FipeBrasil.Application.DTOs;
using FipeBrasil.Domain.Contracts;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Queries
{
    public class GetVehicleYearsHandler : IRequestHandler<GetVehicleYearsQuery, IEnumerable<VehicleYearDto>>
    {
        private readonly IRepository<Domain.Entities.VehicleYear> _vehicleYearRepository;

        public GetVehicleYearsHandler(IRepository<Domain.Entities.VehicleYear> vehicleYearRepository)
        {
            _vehicleYearRepository = vehicleYearRepository;
        }

        public async Task<IEnumerable<VehicleYearDto>> Handle(GetVehicleYearsQuery request, CancellationToken cancellationToken)
        {
            var vehicleYears = await _vehicleYearRepository.GetAllAsync();
            return vehicleYears
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(vy => new VehicleYearDto
                {
                    Id = vy.Id,
                    Code = vy.Code,
                    Name = vy.Name
                });
        }
    }
}
