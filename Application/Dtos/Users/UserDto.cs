namespace Application.Dtos.Users
{
    public class UserDto(string accessToken)
    {
        public string AccessToken { get; set; } = accessToken;
    }
}