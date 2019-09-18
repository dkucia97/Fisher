using Fisher.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fisher.Infrastructure.EF
{
    public class FisherDbContext:DbContext
    {
        public DbSet<Note> Notes;
        public DbSet<NotePackage> NotePackages;
        public DbSet<User> Users;
    }
}