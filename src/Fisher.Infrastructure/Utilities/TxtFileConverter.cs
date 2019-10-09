using System;
using System.Collections.Generic;
using System.IO;
using Fisher.Core.Domain;
using Fisher.Core.Utilities;

public class TxtFileConverter : INoteFileConverterStrategy
{
    public FileType Type { get; } = FileType.Txt;

    public IList<Note> Convert(Stream stream)
    {
        var results=new List<Note>();
        using (var reader = new StreamReader(stream))
        {
            int lineNumber = 0;
            while (!reader.EndOfStream)
            {
                string[] elements = reader.ReadLine()?.Split(";");
                lineNumber++;
                if (elements.Length != 2)
                {
                    throw new ArgumentException($"Incorect format in line{lineNumber} ");
                }
                results.Add(new Note(elements[0],elements[1]));
            }
        }
        stream.Dispose();
        return results;
    }
}
    
