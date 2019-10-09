using System.Threading.Tasks;
using Fisher.Core.Domain;

namespace Fisher.Core.Services
{
    public interface IAuthService
    {
        Task Register(User user, string password);
        Task<User> Login(string userName, string password);
    }
}