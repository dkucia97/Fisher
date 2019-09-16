using System.Collections.Generic;
using System.Threading.Tasks;
using Fisher.Core.Domain;

namespace Fisher.Core.Data.Repositories
{
    public interface INotePackageRepository
    {
        Task Add(NotePackage package);
        Task Update(NotePackage package);
        Task<NotePackage> GetById(int id);
        Task<IEnumerable<NotePackage>> GetByUser(string userName);
        Task<IEnumerable<NotePackage>> GetAllPublic(int numberOfPage, Order order,int size = 10);
        Task<IEnumerable<NotePackage>> GetAllByRate(int numberOfPage, Order order,int  size = 10);
        Task<IEnumerable<NotePackage>> GetAllByFollowers(int numberOfPage,Order order, int size = 10);
    }
}