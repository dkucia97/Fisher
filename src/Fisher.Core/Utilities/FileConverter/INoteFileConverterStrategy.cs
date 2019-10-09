using System.Collections;
using System.Collections.Generic;
using System.IO;
using Fisher.Core.Domain;

namespace Fisher.Core.Utilities
{
    public interface INoteFileConverterStrategy    
    {
        FileType Type { get; }
        IList<Note> Convert(Stream stream);
    }
}