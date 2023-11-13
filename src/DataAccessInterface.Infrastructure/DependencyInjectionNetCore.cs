using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataAccessInterface.Application.Services;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Infrastructure.Repository;
using DataAccessInterface.Infrastructure.Context;
using DataAccessInterface.Abstractions.Repository;
using CentralizerInterface.Domain.Abstractions.Services;

namespace DataAccessInterface.Infrastructure
{
    public static class DependencyInjectionNetCore
    {
        public static void AddInterfaceLoggerServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                DbContextOptionsBuilder dbContextOptionsbuilder = option.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICatRepository, CatRepository>();

            services.AddTransient<ICentralizerService, CentralizerService>();
        }
    }
}
