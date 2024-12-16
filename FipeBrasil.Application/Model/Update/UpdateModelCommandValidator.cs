using FluentValidation;

namespace FipeBrasil.Application.Model.Update
{
    public class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
    {
        public UpdateModelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Code).NotNull().WithMessage("Code is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100);
        }
    }
}
