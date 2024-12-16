using MediatR;

namespace FipeBrasil.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private readonly List<INotification> _domainEvents = new List<INotification>();

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
