using MediatR;

namespace FipeBrasil.Application.Model.Create
{
    public class CreateModelCommand : IRequest<CreateModelResponse>
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid BrandId { get; set; }
    }
}
