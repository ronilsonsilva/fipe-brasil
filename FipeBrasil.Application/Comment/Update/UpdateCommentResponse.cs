using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Comment.Update
{
    public class UpdateCommentResponse : CommentDto
    {
        public static UpdateCommentResponse From(Domain.Entities.Comment comment)
        {
            return new UpdateCommentResponse
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
