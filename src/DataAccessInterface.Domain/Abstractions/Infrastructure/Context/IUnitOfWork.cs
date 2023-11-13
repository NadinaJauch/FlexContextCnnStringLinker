using System.Threading;
using System.Threading.Tasks;

namespace DataAccessInterface.Abstractions.Context
{
    public interface IUnitOfWork
    {
        IApplicationDbContext Context { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
