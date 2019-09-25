using Fisher.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Fisher.Infrastructure.EF
{
    public class FisherDbContext:DbContext
    {
        private SqlSettings _sqlSettings;
        public DbSet<Note> Notes;
        public DbSet<NotePackage> NotePackages;
        public DbSet<User> Users;
        
        public FisherDbContext(DbContextOptions<FisherDbContext> options,IOptions<SqlSettings> sqlSettings):base(options)
        {
            _sqlSettings = sqlSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureNotePackages(modelBuilder);
        }

        private void ConfigureNotePackages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotePackage>().HasMany<Note>(n => n.Notes);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<FavoriteNotePackage>(u => u.FavoriteNotePackages);
            modelBuilder.Entity<User>().HasMany<NotePackage>(u => u.NotePackages)
                .WithOne(n => n.Owner);
            
        }
    }
}