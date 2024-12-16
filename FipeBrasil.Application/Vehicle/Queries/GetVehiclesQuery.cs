using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Queries
{
    public class GetVehiclesQuery : IRequest<IEnumerable<VehicleDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
