using Microsoft.AspNetCore.Mvc;
using HmzTest.Mappers;
using HmzTest.Interfaces;
using HmzTest.Dtos.User;
using HmzTest.Dtos.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace HmzTest.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(PaginatedDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaginatedDto<UserDto>>> GetAll([FromQuery] GetAllUsersRequest query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _userRepository.GetPaginatedUsersAsync(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null) return NotFound("User not found.");

            return Ok(user.ToUserDto());
        }

        [HttpPatch("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userRepository.UpdateAsync(id, body);
            if (result == null)
            {
                return NotFound("User not found.");
            }

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id);
            if (deletedUser == null) return NotFound("User not found.");

            return NoContent();
        }
    }
}
