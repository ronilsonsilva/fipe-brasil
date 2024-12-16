using FluentValidation;

namespace FipeBrasil.Application.Comment.Delete
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
