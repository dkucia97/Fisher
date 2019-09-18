using System.Threading.Tasks;
using Fisher.Core.Domain;

namespace Fisher.Core.Data.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task Update(User user);
        Task<bool> IsUserExist(string  userName);
        Task<User> GetById(int id);
        Task<User> GetByName(string name);

    }
}