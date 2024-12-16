using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Vehicle.Create
{
    public class CreateVehicleResponse : VehicleDto
    {
        public static CreateVehicleResponse From(Domain.Entities.Vehicle vehicle)
        {
            return new CreateVehicleResponse
            {
                Id = vehicle.Id,
                BrandName = vehicle.BrandName,
                ModelName = vehicle.ModelName,
                Price = vehicle.Price,
                ModelYear = vehicle.ModelYear,
                FuelType = vehicle.FuelType
            };
        }
    }
}
