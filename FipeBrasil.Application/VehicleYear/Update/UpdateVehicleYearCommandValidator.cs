using FluentValidation;

namespace FipeBrasil.Application.VehicleYear.Update
{
    public class UpdateVehicleYearCommandValidator : AbstractValidator<UpdateVehicleYearCommand>
    {
        public UpdateVehicleYearCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
