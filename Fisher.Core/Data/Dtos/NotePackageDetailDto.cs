using System.Collections.Generic;

namespace Fisher.Core.Data.Dtos
{
    public class NotePackageDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<NoteDto> Notes { get; set; }
    }
}