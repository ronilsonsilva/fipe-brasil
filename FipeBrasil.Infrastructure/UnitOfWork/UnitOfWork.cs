using FipeBrasil.Domain.Contracts;
using FipeBrasil.Domain.Entities;
using FipeBrasil.Infrastructure.Data.Context;
using FipeBrasil.Infrastructure.Data.Repositories;

namespace FipeBrasil.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FipeDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(FipeDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new Repository<T>(_context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)_repositories[type];
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
