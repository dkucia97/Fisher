using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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
        public async Task AddNotePackage(string userName, NotePackage package)
        {
           var user= await  _uow.UserRepository.GetByName(userName);
           if (user is null)
           {
               throw new ArgumentException($"User with name {userName} don't exist '");
           }

           var categoryId = package.Category.Id;
           if (! await _uow.NotePackageRepository.IsCategoryExist(categoryId) )
           {
               throw new ArgumentException($"Category with {categoryId} don't exist'");
           }

           package.Owner = user;
           await _uow.NotePackageRepository.Add(package);
           await _uow.Commit();
        }
        
        public async Task<IEnumerable<NotePackage>> GetUserNotes(string userName)
        {
            return await _uow.NotePackageRepository.GetByUser(userName);
        }


        public async Task<IEnumerable<FavoriteNotePackage>>GetUserFavoritePackages(string userName)
        {
            var user = await _uow.UserRepository.GetByName(userName);
            return user.FavoriteNotePackages;
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

    }
}