using MediatR;

namespace FipeBrasil.Application.VehicleYear.Create
{
    public class CreateVehicleYearCommand : IRequest<CreateVehicleYearResponse>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid ModelId { get; set; }
    }
}
