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
        public DbSet<Language> Languages;
        public DbSet<FavoriteNotePackage> FavoriteNotePackages;
        public DbSet<Category> Categories;
        
        public FisherDbContext(DbContextOptions<FisherDbContext> options,IOptions<SqlSettings> sqlSettings):base(options)
        {
            _sqlSettings = sqlSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();
            }
            else
            {
                optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString,
                    b=>b.MigrationsAssembly("Fisher.Infrastructure"));
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureNotePackages(modelBuilder);
            ConfigureFavoriteNodePackage(modelBuilder);
        }

        private void ConfigureFavoriteNodePackage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteNotePackage>().HasOne(f => f.NotePackage).WithMany()
                .HasForeignKey(f => f.NotePackageId);
        }
        
        private void ConfigureNotePackages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotePackage>().HasMany<Note>(n => n.Notes);
          //  modelBuilder.Entity<NotePackage>().HasOne(n => n.Language);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<FavoriteNotePackage>(u => u.FavoriteNotePackages);
            modelBuilder.Entity<User>().HasMany<NotePackage>(u => u.NotePackages)
                .WithOne(n => n.Owner);
            
        }
    }
}