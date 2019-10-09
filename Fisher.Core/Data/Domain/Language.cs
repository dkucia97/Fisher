namespace Fisher.Core.Domain
{
    public class Language:BaseEntity<int>
    {
        public string Code { get; set; } //e.g En ,Pl etc..

        public Language(string code)
        {
            Code = code;
        }
    }
}