namespace FipeBrasil.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string AuthorName { get; private set; } = string.Empty;
        public string AuthorEmail { get; private set; } = string.Empty;
        public string Text { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; } = null!;

        public Comment(string authorName, string authorEmail, string text, Guid vehicleId)
        {
            AuthorName = authorName;
            AuthorEmail = authorEmail;
            Text = text;
            VehicleId = vehicleId;
        }

        public Comment SetAuthorName(string authorName)
        {
            AuthorName = authorName;
            return this;
        }

        public Comment SetAuthorEmail(string authorEmail)
        {
            AuthorEmail = authorEmail;
            return this;
        }

        public Comment SetText(string text)
        {
            Text = text;
            return this;
        }
    }
}
