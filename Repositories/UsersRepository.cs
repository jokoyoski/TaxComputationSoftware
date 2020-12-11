using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxComputationAPI.Data;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories 
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository (DataContext context) 
        {
            _context = context;

        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<PagedList<User>> GetUsersAsync(PaginationParams pagination)
        {
          var users = _context.Users.AsQueryable();
          return await PagedList<User>.CreateAsync(users, pagination.PageNumber, pagination.PageSIze);
        }

        
    }
}