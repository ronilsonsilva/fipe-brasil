using MediatR;

namespace FipeBrasil.Application.Vehicle.Update
{
    public class UpdateVehicleCommand : IRequest<UpdateVehicleResponse>
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int ModelYear { get; set; }
        public string FuelType { get; set; } = string.Empty;
    }
}
