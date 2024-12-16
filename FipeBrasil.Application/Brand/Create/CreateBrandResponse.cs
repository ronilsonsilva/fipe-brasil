using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Brand.Create
{
    public class CreateBrandResponse : BrandDto
    {
        public static CreateBrandResponse From(Domain.Entities.Brand brand)
        {
            return new CreateBrandResponse
            {
                Id = brand.Id,
                Code = brand.Code,
                Name = brand.Name
            };
        }
    }
}
