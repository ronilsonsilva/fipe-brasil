using MediatR;

namespace FipeBrasil.Application.Model.Delete
{
    public class DeleteModelCommand : IRequest<DeleteModelResponse>
    {
        public Guid Id { get; set; }
    }
}
