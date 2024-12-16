using FipeBrasil.Domain.Entities;
using MediatR;

namespace FipeBrasil.Application.Vehicle.Create
{
    public class CreateVehicleCommand : IRequest<CreateVehicleResponse>
    {
        public VehicleType VehicleType { get; private set; }
        public string Price { get; private set; } = string.Empty;
        public string BrandName { get; private set; } = string.Empty;
        public string ModelName { get; private set; } = string.Empty;
        public int ModelYear { get; private set; }
        public string FuelType { get; private set; } = string.Empty;
        public string FipeCode { get; private set; } = string.Empty;
        public string ReferenceMonth { get; private set; } = string.Empty;
        public string FuelAbbreviation { get; private set; } = string.Empty;
        public Guid ModelId { get; private set; }
    }
}
