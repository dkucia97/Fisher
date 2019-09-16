using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;

namespace Fisher.Core.Services
{
    public class UserNotesServices:IUserNotesService
    {
        private IUnitOfWork _uow;

        public UserNotesServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<IEnumerable<NotePackage>> GetUserNotes(string userName)
        {
            return await _uow.NotePackageRepository.GetByUser(userName);
        }

        public async Task PublishUserNotePackage(string userName,int packageId)
        {
            var package = await _uow.NotePackageRepository.GetById(packageId);
            if (package == null)
            {
                throw  new ArgumentException($"Package with {packageId} id doesn't exist");
            }
            if (!package.Owner.UserName.Equals(userName))
            {
                throw  new ArgumentException($"Package with {packageId} id does not belong to you");
            }

            package.IsPublic = true;
            await _uow.Commit();
        }

        public async Task ImportNotePackageFromFile()
        {
            throw new System.NotImplementedException();
        }
    }
}