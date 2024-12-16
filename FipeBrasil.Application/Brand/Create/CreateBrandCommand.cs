using MediatR;

namespace FipeBrasil.Application.Brand.Create
{
    public class CreateBrandCommand : IRequest<CreateBrandResponse>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
