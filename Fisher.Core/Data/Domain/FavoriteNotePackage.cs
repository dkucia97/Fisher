namespace Fisher.Core.Domain
{
    public class FavoriteNotePackage:BaseEntity<int>
    {
        public int NotePackageId { get; set; }
        public string Title { get; set; }
        public virtual Category Category { get; set; }
        public virtual NotePackage NotePackage { get; set; }
    }
}