using System;
using System.Text;

namespace Fisher.Core.Domain
{    //value object 
    public class Note : BaseEntity<int>
    {
        public string Front { get; set; }
        public string Back { get; set; }
        public string Definition { get; set; } = String.Empty;

        public Note(string front, string back)
        {
            Front = front;
            Back = back;
        }

        public Note() { }
    }
}