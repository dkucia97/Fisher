using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Core.Services
{
    public interface INotesService
    {
        Task<IEnumerable<NotePackage>> GetByCategory(int categoryId, PaginationRequest page);
        Task<IEnumerable<NotePackage>> GetAllPublicByFollowersAmount(PaginationRequest page);
        Task FollowNotePackage(string userName, int packageId);
        Task UnFollowNotePackage(string userName,int packageId);
      
    }
}