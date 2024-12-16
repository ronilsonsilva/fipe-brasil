using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Vehicle.Update
{
    public class UpdateVehicleResponse : VehicleDto
    {
        public static UpdateVehicleResponse From(Domain.Entities.Vehicle vehicle)
        {
            return new UpdateVehicleResponse
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
