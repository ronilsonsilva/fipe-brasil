using MediatR;

namespace FipeBrasil.Application.Model.Update
{
    public class UpdateModelCommand : IRequest<ModelUpdateResponse>
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
