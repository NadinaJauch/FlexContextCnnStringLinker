using System.Threading;
using System.Threading.Tasks;
using DataAccessInterface.Abstractions.Context;

namespace DataAccessInterface.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationDbContext Context { get; }

        public UnitOfWork(IApplicationDbContext context)
        {
            Context = context;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
