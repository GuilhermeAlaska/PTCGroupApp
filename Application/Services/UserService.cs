using Application.Common;
using Application.Common.Interfaces;
using Application.Dtos.Users;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<BaseResult<UserDto>> CreateUser(string name, string email, string password)
        {
            var existingUser = await context.Users.SingleOrDefaultAsync(
                user => user.Email.Trim().ToLower() == email.Trim().ToLower());

            var isInserting = true;

            if (existingUser is not null)
            {
                if (!existingUser.IsActive)
                {
                    existingUser.Reactivate();
                    isInserting = false;
                }
                else
                {
                    return new BaseResult<UserDto>(400, "Já existe um usuário com o mesmo e-mail.");
                }
            }

            var hashedPassword = passwordService.Hash(password);

            var userToRegister = existingUser ?? new User(name, email, hashedPassword);

            if (isInserting)
            {
                context.Users.Add(userToRegister);
            }
            else
            {
                userToRegister.UpdateName(name);
                userToRegister.UpdatePassword(hashedPassword);

                context.Users.Update(userToRegister);
            }

            await context.SaveChangesAsync(new CancellationToken());

            return new BaseResult<UserDto>(200, "Usuário criado com sucesso.", true);
        }

        public async Task<BaseResult<UserDto>> DeleteUser(Guid userId)
        {
            var user = await context
                   .Users
                   .FirstOrDefaultAsync(p => p.Id == userId);

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");
            else
                user.Deactivate();

            await context.SaveChangesAsync(new CancellationToken());

            return new BaseResult<UserDto>(200, "Sucesso", true);
        }

        public async Task<BaseResult<UserDto>> SignIn(string email, string password)
        {
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(p => p.Email == email.ToLower());

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");

            if (!passwordService.Verify(user.Password, password))
                return new BaseResult<UserDto>(400, "Email ou senha inválidos.");

            await context.SaveChangesAsync(new CancellationToken());

            var token = jwtService.ApplicationAccessToken(
                user.Id.ToString());

            return new BaseResult<UserDto>(200, token, true);
        }

        public async Task<BaseResult<UserDto>> UpdatePassword(string password, string actualPassword, Guid userId)
        {
            var passwordHash = passwordService.Hash(password);
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(p => p.Id == userId);

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");

            if (!string.IsNullOrWhiteSpace(actualPassword))
            {
                if (!passwordService.Verify(user.Password, actualPassword))
                    return new BaseResult<UserDto>(400, "Email ou senha inválidos.");
            }

            user.UpdatePassword(passwordHash);
            await context.SaveChangesAsync(new CancellationToken());

            return new BaseResult<UserDto>(200, "Sucesso", true);
        }

        public async Task<BaseResult<UserDto>> UpdateUser(Guid userId, string? name, string? email)
        {
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(p => p.Id == userId);

            if (user is null)
                return new BaseResult<UserDto>(404, "Usuário não encontrado.");

            if (!string.IsNullOrEmpty(name))
                user.UpdateName(name);

            if (!string.IsNullOrEmpty(email))
                user.UpdateEmail(email);

            await context.SaveChangesAsync(new CancellationToken());

            return new BaseResult<UserDto>(200, "Sucesso", true);
        }
    }
}