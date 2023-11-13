using System.Threading;
using System.Threading.Tasks;
using DataAccessInterface.Domain.DTOs;
using DataAccessInterface.Domain.Entities;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Abstractions.Repository;
using CentralizerInterface.Domain.Abstractions.Services;

namespace DataAccessInterface.Application.Services
{
    public class CentralizerService : ICentralizerService
    {
        private readonly ICatRepository _catRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CentralizerService(ICatRepository catRepository,
                                  IPersonRepository personRepository,
                                  IUnitOfWork unitOfWork)
        {
            _catRepository = catRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AssignOwnerToCatById(int catId, 
                                               PersonDetailsDTO personDetailsDTO, 
                                               CancellationToken cancellationToken)
        {
           Cat cat = await _catRepository.GetByIdAsync(catId);
           Person person = await _personRepository.GetPersonByDetails(personDetailsDTO.Age, 
                                                                      personDetailsDTO.LastName, 
                                                                      personDetailsDTO.FirstName);
           cat.Person = person;
           _catRepository.Update(cat);
           await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
