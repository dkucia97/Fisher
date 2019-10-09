using System;
using System.Text;
using System.Threading.Tasks;
using Fisher.Core.Data.Repositories;
using Fisher.Core.Domain;
using Fisher.Core.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void FollowNotePackage_InvalidId_ExceptionThrow()
        {
            var userRepo =
                Mock.Of<IUserRepository>(u => 
                    u.GetByName(It.IsAny<string>()) == Task.FromResult(new User()));
            var noteRepo = Mock.Of<INotePackageRepository>(
                n => n.GetById(It.IsAny<int>()) == Task.FromResult<NotePackage>(null));
            var uow = Mock.Of<IUnitOfWork>(e => e.UserRepository == userRepo
                                                && e.NotePackageRepository == noteRepo);
            INotesService notesService=new NotesService(uow);
            Func<Task> action = async () => await notesService.FollowNotePackage("sampleUserNam", 1);
            action.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void FollowNotePackage_PackageIsNotPublic_ExceptionThrow()
        {
            var userRepo =
                Mock.Of<IUserRepository>(u => 
                    u.GetByName(It.IsAny<string>()) == Task.FromResult(new User()));
            var noteRepo = Mock.Of<INotePackageRepository>(
                n => n.GetById(It.IsAny<int>()) == Task.FromResult(new NotePackage(){IsPublic = false}));
            var uow = Mock.Of<IUnitOfWork>(e => e.UserRepository == userRepo
                                                && e.NotePackageRepository == noteRepo);
            INotesService notesService=new NotesService(uow);
            Func<Task> action = async () => await notesService.FollowNotePackage("sampleUserNam", 1);
            action.Should().Throw<ArgumentException>();
        }
    }
}