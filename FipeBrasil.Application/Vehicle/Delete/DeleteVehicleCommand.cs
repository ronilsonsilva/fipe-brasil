using MediatR;

namespace FipeBrasil.Application.Vehicle.Delete
{
    public class DeleteVehicleCommand : IRequest<DeleteVehicleResponse>
    {
        public Guid Id { get; set; }
    }
}
