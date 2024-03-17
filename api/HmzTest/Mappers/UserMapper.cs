using HmzTest.Dtos.User;
using HmzTest.Models;

namespace HmzTest.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this UserModel userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.UserName,
                Email = userModel.Email,
            };
        }
    }
}
