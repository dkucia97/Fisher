using System.Threading.Tasks;

namespace Fisher.Core.Data.Repositories
{   //not the best approach. Specific repositories are hard coded 
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        INotePackageRepository NotePackageRepository { get; }
        Task Commit();
    }
}