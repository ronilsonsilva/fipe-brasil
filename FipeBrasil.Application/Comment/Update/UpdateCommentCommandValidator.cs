using FluentValidation;

namespace FipeBrasil.Application.Comment.Update
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
        }
    }
}
