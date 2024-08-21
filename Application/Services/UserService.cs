using Application.Common;
using Application.Common.Interfaces;
using Application.Dtos.Users;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext context;
        private readonly IPasswordService passwordService;
        private readonly IJwtService jwtService;

        public UserService(IApplicationDbContext context, IPasswordService passwordService, IJwtService jwtService)
        {
            this.context = context;
            this.passwordService = passwordService;
            this.jwtService = jwtService;
        }

        public Task<BaseResult<UserDto>> CreateNewPassword()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<UserDto>> CreateUser()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<UserDto>> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<UserDto>> SignIn(string email, string password, CancellationToken cancellationToken)
        {
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(p => p.Email == email.ToLower(), cancellationToken);

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");

            if (!passwordService.Verify(user.Password, password))
                return new BaseResult<UserDto>(400, "Email ou senha inválidos.");

            await context.SaveChangesAsync(cancellationToken);

            var token = jwtService.ApplicationAccessToken(
                user.Id.ToString(),
                user.Roles.ToArray());

            return new BaseResult<UserDto>(200, token);
        }

        public async Task<BaseResult<UserDto>> UpdatePassword(string password, string actualPassword, Guid userId, CancellationToken cancellationToken)
        {
            var passwordHash = passwordService.Hash(password);
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(p => p.Id == userId, cancellationToken);

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");

            if (!string.IsNullOrWhiteSpace(actualPassword))
            {
                if (!passwordService.Verify(user.Password, actualPassword))
                    return new BaseResult<UserDto>(400, "Email ou senha inválidos.");
            }

            user.UpdatePassword(passwordHash);
            await context.SaveChangesAsync(cancellationToken);
            return new BaseResult<UserDto>(200, "Sucesso", true);
        }

        public Task<BaseResult<UserDto>> UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}