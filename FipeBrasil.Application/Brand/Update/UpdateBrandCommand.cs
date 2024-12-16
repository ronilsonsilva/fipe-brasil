using MediatR;

namespace FipeBrasil.Application.Brand.Update
{
    public class UpdateBrandCommand : IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
