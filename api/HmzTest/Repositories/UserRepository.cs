using HmzTest.Data;
using HmzTest.Dtos.Helpers;
using HmzTest.Dtos.User;
using HmzTest.Interfaces;
using HmzTest.Mappers;
using HmzTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HmzTest.Repositories
{
    public class UserRepository(ApplicationDbContext context, UserManager<UserModel> userManager) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<UserModel> _userManager = userManager;

        public async Task<PaginatedDto<UserDto>> GetPaginatedUsersAsync(GetAllUsersRequest query)
        {
            var totalItems = await _context.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)query.PerPage);

            if (totalPages == 0)
            {
                return new PaginatedDto<UserDto>(query.Page, totalPages, query.PerPage, totalItems, []);
            }

            query.Page = Math.Max(1, query.Page);
            query.Page = Math.Min(totalPages, query.Page);

            var users = await _context.Users
                              .Skip((query.Page - 1) * query.PerPage)
                              .Take(query.PerPage)
                              .Select(u => u.ToUserDto())
                              .ToListAsync();

            return new PaginatedDto<UserDto>(query.Page, totalPages, query.PerPage, totalItems, users);
        }

        public async Task<UserModel?> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IdentityResult?> UpdateAsync(string id, UpdateUserRequestDto updateUserRequestDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            if (!string.IsNullOrWhiteSpace(updateUserRequestDto.Username))
            {
                user.UserName = updateUserRequestDto.Username;
            }

            if (!string.IsNullOrWhiteSpace(updateUserRequestDto.Email))
            {
                var existingUserByEmail = await _userManager.FindByEmailAsync(updateUserRequestDto.Email);
                if (existingUserByEmail != null && existingUserByEmail.Id != user.Id)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Email already in use." });
                }
                else
                {
                    var setEmailResult = await _userManager.SetEmailAsync(user, updateUserRequestDto.Email);
                    if (!setEmailResult.Succeeded) return setEmailResult;
                }
            }

            if (!string.IsNullOrWhiteSpace(updateUserRequestDto.Password))
            {
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (!removePasswordResult.Succeeded) return removePasswordResult;

                var addPasswordResult = await _userManager.AddPasswordAsync(user, updateUserRequestDto.Password);
                if (!addPasswordResult.Succeeded) return addPasswordResult;
            }

            var updateResult = await _userManager.UpdateAsync(user);
            return updateResult;
        }

        public async Task<UserModel?> DeleteAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user is null) return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
