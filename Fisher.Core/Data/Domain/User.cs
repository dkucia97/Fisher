using System;
using System.Collections.Generic;

namespace Fisher.Core.Domain
{
    public class User:BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<NotePackage> NotePackages { get; set; }
        public ICollection<FavoriteNotePackage> FavoriteNotePackages { get; set; }

        public User()
        {
            NotePackages=new List<NotePackage>();
            FavoriteNotePackages=new List<FavoriteNotePackage>();
        }
    }
}