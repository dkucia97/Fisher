using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fisher.Core.Domain;

namespace Fisher.Core.Services
{
    public interface IUserNotesService
    {
        Task AddNotePackage(string userName, NotePackage package);
        Task<IEnumerable<FavoriteNotePackage>> GetUserFavoritePackages(string userName);
        Task<IEnumerable<NotePackage>> GetUserNotes(string userName);
        Task PublishUserNotePackage(string userName,int packageId);
    }
}