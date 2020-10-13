using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(int id);
        Task<PagedList<User>> GetUsersAsync(PaginationParams pagination);
    }
}