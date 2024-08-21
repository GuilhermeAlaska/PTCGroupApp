using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}