using System;
using System.Collections.Generic;

namespace Fisher.Core.Domain
{   //aggregate root 
    public class NotePackage:BaseEntity<int>
    {
        public string Title { get; set; }
        public bool IsPublic { get; set; } = false;
        public long FollowersAmount { get; set; }
        
        //public Language Language { get; set; }
        public virtual Category Category { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Note> Notes { get; set; }

        public NotePackage()
        {
            Notes=new List<Note>();
        }
        
    }
}