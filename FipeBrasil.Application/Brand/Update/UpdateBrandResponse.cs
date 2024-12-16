using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Brand.Update
{
    public class UpdateBrandResponse : BrandDto
    {
        public static UpdateBrandResponse From(Domain.Entities.Brand brand)
        {
            return new UpdateBrandResponse
            {
                Id = brand.Id,
                Code = brand.Code,
                Name = brand.Name
            };
        }
    }
}
