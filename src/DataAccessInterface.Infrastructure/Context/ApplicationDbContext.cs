using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessInterface.Domain.Entities;
using DataAccessInterface.Abstractions.Context;

namespace DataAccessInterface.Infrastructure.Context
{ 
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Cat> Cat { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }

}
