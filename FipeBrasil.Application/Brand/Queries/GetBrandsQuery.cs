using MediatR;

namespace FipeBrasil.Application.Brand.Queries
{
    public class GetBrandsQuery : IRequest<GetBrandsQueryResult>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
