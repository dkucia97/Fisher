using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Core.Services
{
    public class NotesService:INotesService
    {
        private readonly IUnitOfWork _uow;

        public NotesService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<NotePackage> GetById(string userName, int id)
        {
            var package = await _uow.NotePackageRepository.GetById(id);
            if (!package.IsPublic && package.Owner.UserName.Equals(userName))
            {
                throw new ArgumentException("You don't have access to this package (it's private)");
            }

            return package;
        }

        public Task<IEnumerable<NotePackage>> GetByCategory(int categoryId, PaginationRequest page)
        {
            return _uow.NotePackageRepository.GetByCategory(categoryId, page);
        }

        public Task<IEnumerable<NotePackage>> GetAllPublicByFollowersAmount(PaginationRequest page)
        {
            return _uow.NotePackageRepository.GetAllPublicByFollowersAmount(page);
        }

        public async Task FollowNotePackage(string userName, int packageId)
        {
            var user = await _uow.UserRepository.GetByName(userName);
            var package = await _uow.NotePackageRepository.GetById(packageId);
            if (package == null)
            {
                throw  new ArgumentException($"Package with {packageId} id doesn't exist");
            }

            if (!package.IsPublic)
            {
                throw new ArgumentException($"Package with {packageId} id is not public.You can't follow'");
            }
            package.FollowersAmount++;
            user.FavoriteNotePackages.Add(new FavoriteNotePackage()
            {
                NotePackageId = packageId,
                Category = package.Category,
                Title = package.Title
            });
            await _uow.Commit();
        }

        public async Task UnFollowNotePackage(string userName, int packageId)
        {
            var user = await _uow.UserRepository.GetByName(userName);
            var favoritePackage=user.FavoriteNotePackages.SingleOrDefault(f => f.NotePackageId==packageId);
            if(favoritePackage!=null)
            {
                user.FavoriteNotePackages.Remove(favoritePackage);
                await _uow.Commit();
            }
        }
    }
}