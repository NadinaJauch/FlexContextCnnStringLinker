using DataAccessInterface.Domain.Entities;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Abstractions.Repository;

namespace DataAccessInterface.Infrastructure.Repository
{
    public class CatRepository : BaseRepository<Cat>, ICatRepository
    {
        public CatRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
