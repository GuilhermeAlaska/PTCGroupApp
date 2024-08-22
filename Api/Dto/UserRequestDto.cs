namespace Api.Dto
{
    public class SignInRequest
    {
        public SignInRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserRequest
    {
        public CreateUserRequest(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserRequest
    {
        public UpdateUserRequest(string? name, string? email)
        {
            Name = name;
            Email = email;
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class UpdatePasswordRequest
    {
        public UpdatePasswordRequest(string password, string actualPassword, Guid userId)
        {
            Password = password;
            ActualPassword = actualPassword;
            UserId = userId;
        }

        public string Password { get; set; }
        public string ActualPassword { get; set; }
        public Guid UserId { get; set; }
    }
}
