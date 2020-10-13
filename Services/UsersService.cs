using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services 
{
    public class UsersService : IUsersService 
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService (IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;

        }
        public Task<PagedList<User>> GetUsersAsync(PaginationParams pagination)
        {
            return _usersRepository.GetUsersAsync(pagination);
        }
        public Task<User> GetUserAsync(int id)
        {
            return _usersRepository.GetUserAsync(id);
        }


    }
}