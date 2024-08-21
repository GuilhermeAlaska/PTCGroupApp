namespace Application.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Verify(string key, string password);
    }
}