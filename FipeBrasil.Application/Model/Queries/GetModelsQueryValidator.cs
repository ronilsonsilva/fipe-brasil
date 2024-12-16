using FluentValidation;

namespace FipeBrasil.Application.Model.Queries
{
    public class GetModelsQueryValidator : AbstractValidator<GetModelsQuery>
    {
        public GetModelsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page must be greater than 0.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than 0.");
        }
    }
}
