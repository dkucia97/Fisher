using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Fisher.Core.Services
{
    public interface INotesService
    {
        Task FollowNotePackage(string userName, int packageId);
    }
}