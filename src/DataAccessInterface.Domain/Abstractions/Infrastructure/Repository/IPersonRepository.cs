using System.Threading.Tasks;
using DataAccessInterface.Domain.Entities;

namespace DataAccessInterface.Abstractions.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<Person> GetPersonByDetails(int age,
                                        string lastName,
                                        string firstName);
    }
}
