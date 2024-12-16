using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Model.Update
{
    public class ModelUpdateResponse : ModelDto
    {
        public static ModelUpdateResponse From(Domain.Entities.Model model)
        {
            return new ModelUpdateResponse
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name
            };
        }
    }
}
