using FipeBrasil.Application.DTOs;
using MediatR;

namespace FipeBrasil.Application.Model.Queries
{
    public class GetModelsQuery : IRequest<IEnumerable<ModelDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
