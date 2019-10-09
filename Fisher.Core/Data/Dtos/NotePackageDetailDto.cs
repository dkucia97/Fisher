using System.Collections.Generic;

namespace Fisher.Core.Data.Dtos
{
    public class NotePackageDetailDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<NoteDto> Notes { get; set; }
    }
}