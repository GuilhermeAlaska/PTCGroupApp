using Application.Common;
using Application.Dtos.Users;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<BaseResult<UserDto>> CreateUser();
        public Task<BaseResult<UserDto>> UpdateUser();
        public Task<BaseResult<UserDto>> DeleteUser();
        public Task<BaseResult<UserDto>> SignIn(string email, string password, CancellationToken cancellationToken);
        public Task<BaseResult<UserDto>> CreateNewPassword();
        public Task<BaseResult<UserDto>> UpdatePassword(string password, string actualPassword, Guid userId, CancellationToken cancellationToken);
    }
}