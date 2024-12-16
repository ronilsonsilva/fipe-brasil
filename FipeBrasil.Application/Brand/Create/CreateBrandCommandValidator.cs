using FluentValidation;

namespace FipeBrasil.Application.Brand.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.").MaximumLength(10);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100);
        }
    }
}
