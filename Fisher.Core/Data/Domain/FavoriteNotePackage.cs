namespace Fisher.Core.Domain
{
    public class FavoriteNotePackage:BaseEntity<int>
    {
        public int NotePackageId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
    }
}