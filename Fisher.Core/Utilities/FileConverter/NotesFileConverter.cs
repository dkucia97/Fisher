using System;
using System.Collections.Generic;
using System.IO;
using Fisher.Core.Domain;
using Microsoft.AspNetCore.Http;

namespace Fisher.Core.Utilities
{
    public class NotesFileConverter : IFileConverter<Note>
    {
        private INoteFileStrategyResolver _resolver;

        public NotesFileConverter(INoteFileStrategyResolver resolver)
        {
            _resolver = resolver;
        }


        public IEnumerable<Note> Convert(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            switch (extension.ToUpper())
            {
                case "TXT":
                    return _resolver.Resolve(FileType.Txt).Convert(file.OpenReadStream());
                case "CSV":
                    return _resolver.Resolve(FileType.Csv).Convert(file.OpenReadStream());
                default:
                    throw new ArgumentException("Not supported file type ");
            }
        }
    }
}