using FluentValidation;

namespace FipeBrasil.Application.Model.Create
{
    public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
    {
        public CreateModelCommandValidator()
        {
            RuleFor(x => x.Code).NotNull().WithMessage("Code is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100);
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required.");
        }
    }
}
