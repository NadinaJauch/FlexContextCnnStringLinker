using System.Threading.Tasks;
using DataAccessInterface.Domain.Entities;

namespace DataAccessInterface.Abstractions.Repository
{
    public interface ICatRepository
    {
        Task<Cat> GetByIdAsync(int id);
        void Update(Cat entity);
    }
}
