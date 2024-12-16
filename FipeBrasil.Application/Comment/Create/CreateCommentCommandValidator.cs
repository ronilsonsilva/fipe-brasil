using FluentValidation;

namespace FipeBrasil.Application.Comment.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("AuthorName is required.");
            RuleFor(x => x.AuthorEmail).NotEmpty().WithMessage("AuthorEmail is required.").EmailAddress();
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
            RuleFor(x => x.VehicleId).NotEmpty().WithMessage("VehicleId is required.");
        }
    }
}
