using FluentValidation;

namespace FipeBrasil.Application.Vehicle.Delete
{
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
