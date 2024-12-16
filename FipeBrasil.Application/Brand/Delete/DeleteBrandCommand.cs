using MediatR;

namespace FipeBrasil.Application.Brand.Delete
{
    public class DeleteBrandCommand : IRequest<DeleteBrandResponse>
    {
        public Guid Id { get; set; }
    }
}
