using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;
using Fisher.Infrastructure.EF;
using Fisher.Infrastructure.Exstensions;
using Microsoft.EntityFrameworkCore;

namespace Fisher.Infrastructure.Repositories
{
    public class NotePackageRepository : INotePackageRepository
    {
        private FisherDbContext _context;

        public NotePackageRepository(FisherDbContext dbContext)
        {
            _context = dbContext;
        }

        public Task Add(NotePackage package)
        {
            return _context.NotePackages.AddAsync(package);
        }


        public Task<NotePackage> GetById(int id)
        {
            return _context.NotePackages.SingleOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<NotePackage>> GetByUser(string userName)
        {
            return await _context.NotePackages.Where(n => n.Owner.UserName.Equals(userName)).ToListAsync();
        }

        public async Task<IEnumerable<NotePackage>> GetByCategory(int categoryId, PaginationRequest page) =>
            await _context.NotePackages.Where(n => n.Category.Id == categoryId).GetPage(page).ToListAsync();


        public async Task<IEnumerable<NotePackage>>
            GetAllPublicByFollowersAmount( PaginationRequest page) =>
            await _context.NotePackages.Where(n => n.IsPublic).OrderBy(n => n.FollowersAmount).GetPage(page).ToListAsync();

    }
}