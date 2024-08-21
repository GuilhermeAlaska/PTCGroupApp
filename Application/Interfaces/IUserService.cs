using Application.Common;
using Application.Dtos.Users;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<BaseResult<UserDto>> SignIn(string email, string password);
        public Task<BaseResult<UserDto>> CreateUser(string name, string email, string password);
        public Task<BaseResult<UserDto>> UpdateUser(Guid userId, string? name, string? email);
        public Task<BaseResult<UserDto>> UpdatePassword(string password, string actualPassword, Guid userId);
        public Task<BaseResult<UserDto>> DeleteUser(Guid userId);
    }
}