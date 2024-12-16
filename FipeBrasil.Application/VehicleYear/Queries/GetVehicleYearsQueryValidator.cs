using FluentValidation;

namespace FipeBrasil.Application.VehicleYear.Queries
{
    public class GetVehicleYearsQueryValidator : AbstractValidator<GetVehicleYearsQuery>
    {
        public GetVehicleYearsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page must be greater than 0.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than 0.");
        }
    }
}
