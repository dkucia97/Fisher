using System.Linq;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Fisher.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FisherDbContext _context;

        public UserRepository(FisherDbContext context)
        {
            _context = context;
        }

        public Task Add(User user) => _context.Users.AddAsync(user);


        public async Task<bool> IsUserExist(string userName) =>
            await _context.Users.AnyAsync(u => u.UserName.Equals(userName));

        public async Task<User> GetById(int id) => await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        public async Task<User> GetByName(string name) =>
            await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(name));
    }
}