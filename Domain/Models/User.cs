using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Models
{
    public class User : EntityBase
    {
        protected User() => Expression.Empty();

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email.ToLower();
            Password = password;
            IsActive = true;
        }

        public string Name { get; protected set; } = null!;
        public string Email { get; protected set; } = null!;
        public string Password { get; protected set; } = null!;
        public bool IsActive { get; protected set; } = true;
        public IList<Post> Posts { get; set; } = new List<Post>();

        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void Deactivate() => IsActive = false;
        public void Reactivate() => IsActive = true;
    }
}