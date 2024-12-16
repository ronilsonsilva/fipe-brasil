using MediatR;

namespace FipeBrasil.Application.VehicleYear.Delete
{
    public class DeleteVehicleYearCommand : IRequest<DeleteVehicleYearResponse>
    {
        public Guid Id { get; set; }
    }
}
