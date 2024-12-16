using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.VehicleYear.Delete
{
    public class DeleteVehicleYearResponse : VehicleYearDto
    {
        public static DeleteVehicleYearResponse From(Domain.Entities.VehicleYear vehicleYear)
        {
            return new DeleteVehicleYearResponse
            {
                Id = vehicleYear.Id,
                Code = vehicleYear.Code,
                Name = vehicleYear.Name
            };
        }
    }
}
