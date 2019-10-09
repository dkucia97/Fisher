using System.Collections.Generic;
using System.Threading.Tasks;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Core.Data.Repositories
{
    public interface INotePackageRepository
    {
        Task Add(NotePackage package);
        Task<bool> IsCategoryExist(int categoryId);
        Task<NotePackage> GetById(int id);
        Task<IEnumerable<NotePackage>> GetByUser(string userName);
        Task<IEnumerable<NotePackage>> GetByCategory(int categoryId,PaginationRequest paginationRequest);
        Task<IEnumerable<NotePackage>> GetAllPublicByFollowersAmount( PaginationRequest paginationRequest);
    }
}