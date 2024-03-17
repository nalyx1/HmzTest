using HmzTest.Dtos.Helpers;
using HmzTest.Dtos.User;
using HmzTest.Models;
using Microsoft.AspNetCore.Identity;

namespace HmzTest.Interfaces
{
    public interface IUserRepository
    {
        Task<PaginatedDto<UserDto>> GetPaginatedUsersAsync(GetAllUsersRequest query);
        Task<UserModel?> GetByIdAsync(string id);
        Task<IdentityResult?> UpdateAsync(string id, UpdateUserRequestDto updateUserRequestDto);
        Task<UserModel?> DeleteAsync(string id);
    }
}
