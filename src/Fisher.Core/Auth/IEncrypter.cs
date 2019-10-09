namespace Fisher.Core.Utilities
{
    public interface IEncrypter
    {
        byte[] GetHash(string password, byte[] salt);
        byte[] GenerateRandomSalt(int length=32);
    }
}