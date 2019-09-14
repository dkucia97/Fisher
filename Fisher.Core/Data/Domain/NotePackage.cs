using System;
using System.Collections.Generic;

namespace Fisher.Core.Domain
{   //aggregate root 
    public class NotePackage:BaseEntity<int>
    {
        public string Title { get; set; }
        public bool IsPublic { get; set; } = false;
        public string Description { get; set; }=String.Empty;
        public long FollowersAmount { get; set; }
        public Category Category { get; set; }
        public ICollection<Note> Notes { get; set; }

        public NotePackage()
        {
            Notes=new List<Note>();
        }
        
    }
}