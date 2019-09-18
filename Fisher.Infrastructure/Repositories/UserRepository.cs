using System.Linq;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Fisher.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private FisherDbContext _context;

        public UserRepository(FisherDbContext context)
        {
            _context = context;
        }
        
        public async Task Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsUserExist(string userName)
        {
           return await _context.Users.AnyAsync(u => u.UserName.Equals(userName));
        }

        public async Task<User> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}