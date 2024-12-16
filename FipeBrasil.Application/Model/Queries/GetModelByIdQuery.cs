using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Model.Queries
{
    public class GetModelByIdQuery : IRequest<ModelDto?>
    {
        public Guid Id { get; set; }
    }
}
