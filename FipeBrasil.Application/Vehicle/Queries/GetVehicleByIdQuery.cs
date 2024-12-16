using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Queries
{
    public class GetVehicleByIdQuery : IRequest<VehicleDto?>
    {
        public Guid Id { get; set; }
    }
}
