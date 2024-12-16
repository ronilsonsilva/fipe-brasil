namespace FipeBrasil.Application.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
