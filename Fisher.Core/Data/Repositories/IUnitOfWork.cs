using System.Threading.Tasks;

namespace Fisher.Core.Data.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        INotePackageRepository NotePackageRepository { get; }
        Task Commit();
    }
}