using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Brand.Queries
{
    public class GetBrandByIdQuery : IRequest<BrandDto?>
    {
        public Guid Id { get; set; }
    }
}
