using HmzTest.Dtos.Account;
using HmzTest.Dtos.User;
using HmzTest.Interfaces;
using HmzTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HmzTest.Controllers
{
    public class AccountController(UserManager<UserModel> userManager, ITokenService tokenService, SignInManager<UserModel> signinManager) : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<UserModel> _signinManager = signinManager;


        [HttpPost("register")]
        public async Task<ActionResult<TokenDto>> Register([FromBody] RegisterDto body)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var userModel = new UserModel
                {
                    UserName = body.Username,
                    Email = body.Email,
                };

                var createdUser = await _userManager.CreateAsync(userModel, body.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(userModel, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                        new TokenDto
                        {
                            Token = _tokenService.CreateToken(userModel)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex);
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(body.Email);
            if (user == null) return Unauthorized("Invalid email.");

            var result = await _signinManager.CheckPasswordSignInAsync(user, body.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid email and/or password.");

            return Ok(new TokenDto { Token = _tokenService.CreateToken(user) });
        }
    }
}