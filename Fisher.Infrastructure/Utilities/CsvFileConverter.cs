using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

namespace Fisher.Infrastructure.Utilities
{
    public class CsvFileConverter:INoteFileConverterStrategy
    {
        public FileType Type { get; } = FileType.Csv;

        public IList<Note> Convert(Stream stream)
        {
            using (var reader=new StreamReader(stream))
            {
                using (var csvReader=new CsvReader(reader))
                {
                  var notes=csvReader.GetRecords<Note>();
                  stream.Dispose();
                  return notes.ToList();
                }
            }
        }
    }
}