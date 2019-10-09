using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Infrastructure.EF;

namespace Fisher.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private FisherDbContext _context;
        public IUserRepository UserRepository { get; }
        public INotePackageRepository NotePackageRepository { get; }

        public UnitOfWork(FisherDbContext context)
        {    //Wrong approach .Better approach is use another di container and 
            //resolve method with 
            _context = context;
            UserRepository=new UserRepository(context);
            NotePackageRepository=new NotePackageRepository(context);
        }
        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }
    }
}