using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.VehicleYear.Update
{
    public class UpdateVehicleYearResponse : VehicleYearDto
    {
        public static UpdateVehicleYearResponse From(Domain.Entities.VehicleYear vehicleYear)
        {
            return new UpdateVehicleYearResponse
            {
                Id = vehicleYear.Id,
                Code = vehicleYear.Code,
                Name = vehicleYear.Name
            };
        }
    }
}
