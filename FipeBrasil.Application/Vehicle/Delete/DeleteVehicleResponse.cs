using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Vehicle.Delete
{
    public class DeleteVehicleResponse : VehicleDto
    {
        public static DeleteVehicleResponse From(Domain.Entities.Vehicle vehicle)
        {
            return new DeleteVehicleResponse
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
