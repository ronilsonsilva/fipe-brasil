using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Model.Delete
{
    public class DeleteModelResponse : ModelDto
    {
        public static DeleteModelResponse From(Domain.Entities.Model model)
        {
            return new DeleteModelResponse
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name
            };
        }
    }
}
