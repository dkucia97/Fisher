namespace Fisher.Core.Utilities
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public long ExpireTime { get; set; }   
    }
}