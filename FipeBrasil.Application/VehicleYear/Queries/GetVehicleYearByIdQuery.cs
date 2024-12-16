using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.VehicleYear.Queries
{
    public class GetVehicleYearByIdQuery : IRequest<VehicleYearDto?>
    {
        public Guid Id { get; set; }
    }
}
