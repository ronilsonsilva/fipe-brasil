using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Queries
{
    public class GetVehicleYearsQuery : IRequest<IEnumerable<VehicleYearDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
