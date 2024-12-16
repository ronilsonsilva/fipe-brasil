using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Comment.Create
{
    public class CreateCommentResponse : CommentDto
    {
        public static CreateCommentResponse From(Domain.Entities.Comment comment)
        {
            return new CreateCommentResponse
            {
                Id = comment.Id,
                AuthorName = comment.AuthorName,
                AuthorEmail = comment.AuthorEmail,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt
            };
        }
    }
}
