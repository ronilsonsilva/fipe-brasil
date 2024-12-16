using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.VehicleYear.Create
{
    public class CreateVehicleYearResponse : VehicleYearDto
    {
        public static CreateVehicleYearResponse From(Domain.Entities.VehicleYear vehicleYear)
        {
            return new CreateVehicleYearResponse
            {
                Id = vehicleYear.Id,
                Code = vehicleYear.Code,
                Name = vehicleYear.Name
            };
        }
    }
}
