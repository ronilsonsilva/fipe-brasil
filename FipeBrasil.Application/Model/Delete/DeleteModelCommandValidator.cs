using FluentValidation;

namespace FipeBrasil.Application.Model.Delete
{
    public class DeleteModelCommandValidator : AbstractValidator<DeleteModelCommand>
    {
        public DeleteModelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
