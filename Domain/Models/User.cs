using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Models
{
    public class User : EntityBase
    {
        protected User() => Expression.Empty();

        public User(string name, string email, string password, IList<string> roles)
        {
            Name = name;
            Email = email;
            Password = password;
            Roles = roles;
        }

        public string Name { get; protected set; } = null!;
        public string Email { get; protected set; } = null!;
        public string Password { get; protected set; } = null!;
        public IList<string> Roles { get; protected set; }
        public IList<Post> Posts { get; set; } = new List<Post>();

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}