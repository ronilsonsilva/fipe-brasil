using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Model.Create
{
    public class CreateModelResponse : ModelDto
    {
        public static CreateModelResponse From(Domain.Entities.Model model)
        {
            return new CreateModelResponse
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name
            };
        }
    }
}
