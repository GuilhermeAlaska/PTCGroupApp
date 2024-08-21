namespace Application.Common.Interfaces
{
    public interface IJwtService
    {
        string ApplicationAccessToken(
            string userId);

        string PasswordToken(
            string userId);

        Task<bool> ValidPasswordToken(string token);
    }
}