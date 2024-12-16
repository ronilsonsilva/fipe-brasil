using FluentValidation;

namespace FipeBrasil.Application.Brand.Update
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.").MaximumLength(10);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100);
        }
    }
}
