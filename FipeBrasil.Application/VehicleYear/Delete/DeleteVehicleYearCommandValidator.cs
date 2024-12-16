using FluentValidation;

namespace FipeBrasil.Application.VehicleYear.Delete
{
    public class DeleteVehicleYearCommandValidator : AbstractValidator<DeleteVehicleYearCommand>
    {
        public DeleteVehicleYearCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
