using System.Collections;
using System.Collections.Generic;
using Fisher.Core.Domain;

namespace Fisher.Core.Utilities
{
    public interface INoteFileConverter
    {// it muser recieve parameter , maybe FileStream??
        IList<Note> Convert();
    }
}