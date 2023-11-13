using System.Threading;
using System.Threading.Tasks;
using DataAccessInterface.Domain.DTOs;

namespace CentralizerInterface.Domain.Abstractions.Services
{
    public interface ICentralizerService
    {
        Task AssignOwnerToCatById(int catId, 
                                  PersonDetailsDTO personDetailsDTO,
                                  CancellationToken cancellationToken);
    }
}
