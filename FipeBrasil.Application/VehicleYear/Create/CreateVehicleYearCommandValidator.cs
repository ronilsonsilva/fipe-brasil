using FluentValidation;

namespace FipeBrasil.Application.VehicleYear.Create
{
    // Validators for VehicleYear
    public class CreateVehicleYearCommandValidator : AbstractValidator<CreateVehicleYearCommand>
    {
        public CreateVehicleYearCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("ModelId is required.");
        }
    }
}
