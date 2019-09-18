using System.Security.Authentication;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Core.Services
{
    public class AuthService:IAuthService
    {
        private IUnitOfWork _uow;
        private IEncrypter _encrypter;

        public AuthService(IUnitOfWork uow,IEncrypter encrypter)
        {
            _uow = uow;
            _encrypter = encrypter;
        }
        
        public async Task Register(User user, string password)
        {    //check also email
            var isExist = await _uow.UserRepository.IsUserExist(user.UserName);
            if (isExist)
            {
                throw new AuthenticationException($"Username {user.UserName} is already taken");
            }

            var salt = _encrypter.GenerateRandomSalt();
            user.PasswordHash = _encrypter.GetHash(password,salt);
            user.PasswordSalt = salt;
            await _uow.UserRepository.Add(user);
        }

        public async Task<User> Login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}