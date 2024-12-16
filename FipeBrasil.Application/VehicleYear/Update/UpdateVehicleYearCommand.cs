using MediatR;

namespace FipeBrasil.Application.VehicleYear.Update
{
    public class UpdateVehicleYearCommand : IRequest<UpdateVehicleYearResponse>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
