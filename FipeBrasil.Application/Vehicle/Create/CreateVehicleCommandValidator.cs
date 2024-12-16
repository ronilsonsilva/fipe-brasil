using FluentValidation;

namespace FipeBrasil.Application.Vehicle.Create
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("BrandName is required.");
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("ModelName is required.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.ModelYear).GreaterThan(0).WithMessage("ModelYear must be greater than 0.");
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("FuelType is required.");
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("ModelId is required.");
        }
    }
}
