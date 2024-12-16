using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Brand.Delete
{
    public class DeleteBrandResponse : BrandDto
    {
        public static DeleteBrandResponse From(Domain.Entities.Brand brand)
        {
            return new DeleteBrandResponse
            {
                Id = brand.Id,
                Code = brand.Code,
                Name = brand.Name
            };
        }
    }
}
