using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessInterface.Domain.Entities;

namespace DataAccessInterface.Abstractions.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<Cat> Cat { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
