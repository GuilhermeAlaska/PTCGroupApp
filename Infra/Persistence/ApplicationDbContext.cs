using Application.Common.Interfaces;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Infra.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, IPasswordService passwordService) : base(options)
        {
            _passwordService = passwordService;
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        private readonly IPasswordService _passwordService;
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.AppSeedDataBaseConstructor(_passwordService);

            base.OnModelCreating(builder);
        }
    }
}