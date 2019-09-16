using System;
using System.Net;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;

namespace Fisher.Core.Services
{
    public class NotesService:INotesService
    {
        private readonly IUnitOfWork _uow;

        public NotesService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task FollowNotePackage(string userName, int packageId)
        {
            var user = await _uow.UserRepository.GetByName(userName);
            var package = await _uow.NotePackageRepository.GetById(packageId);
            if (package == null)
            {
                throw  new ArgumentException($"Package with {packageId} id doesn't exist");
            }
            // Should implement unit of work pattern , this method modify two entities ant they must be in one transaction (atomic operation)
            package.FollowersAmount++;
            user.FavoriteNotePackages.Add(new FavoriteNotePackage()
            {
                NotePackageId = packageId,
                Category = package.Category,
                Title = package.Title
            });
            await _uow.Commit();
        }
    }
}