using FipeBrasil.Domain.Entities;

namespace FipeBrasil.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> CommitAsync();
    }
}
