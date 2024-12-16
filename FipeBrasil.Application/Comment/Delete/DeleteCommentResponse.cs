using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Comment.Delete
{
    public class DeleteCommentResponse : CommentDto
    {
        public static DeleteCommentResponse From(Domain.Entities.Comment comment)
        {
            return new DeleteCommentResponse
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
