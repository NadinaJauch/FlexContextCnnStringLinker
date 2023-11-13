using Autofac;
using Microsoft.EntityFrameworkCore;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Application.Services;
using DataAccessInterface.Infrastructure.Context;
using DataAccessInterface.Abstractions.Repository;
using DataAccessInterface.Infrastructure.Repository;
using CentralizerInterface.Domain.Abstractions.Services;

namespace CentralizerInterface.Infrastructure
{
    public static class DependencyInjectionNetFramework
    {
        public static void RegisterInterfaceLoggerServices(this ContainerBuilder builder, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContextOptions = optionsBuilder.Options;
            builder.RegisterInstance(dbContextOptions).As<DbContextOptions<ApplicationDbContext>>();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CatRepository>().As<ICatRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CentralizerService>().As<ICentralizerService>().InstancePerDependency();
        }
    }
}
