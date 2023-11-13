using System.Threading.Tasks;
using DataAccessInterface.Domain.Entities;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Abstractions.Repository;

namespace DataAccessInterface.Infrastructure.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<Person> GetPersonByDetails(int age, 
                                               string lastName, 
                                               string firstName)
        {
            return await GetByConditionAsync(x => x.Age == age &&
                                                  x.LastName == lastName &&
                                                  x.FirstName == firstName);
        }
    }
}
