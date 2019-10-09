using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Fisher.Core.Utilities
{
    public interface IFileConverter<T>
    {
        IEnumerable<T> Convert(IFormFile file );
    }
}