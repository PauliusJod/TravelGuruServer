using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Auth;
using static TravelGuruServer.Data.Dtos.AuthDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace TravelGuruServer.Controllers
{

    [ApiController]
    [AllowAnonymous]  //[Authorize(Roles = TravelUserRoles.TravellerUser)]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<TravelUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<TravelUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (user != null)
                return BadRequest("Request invalid."); // same user

            var newUser = new TravelUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };
            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest("Can't create user.");

            await _userManager.AddToRoleAsync(newUser, TravelUserRoles.TravellerUser);

            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));

        }
        [HttpPut]
        [Route("updatepassword")]
        public async Task<ActionResult> UpdatePassword(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var user = await _userManager.FindByNameAsync(updateUserPasswordDto.UserName);
            if (user == null)
                return NotFound("Request invalid because of user name.");

            if (updateUserPasswordDto.CurrentPassword == updateUserPasswordDto.NewPassword)
            {
                return BadRequest("Please input new password.");
            }

            var result = await _userManager.ChangePasswordAsync(user, updateUserPasswordDto.CurrentPassword, updateUserPasswordDto.NewPassword);

            if (!result.Succeeded)
                return BadRequest("Can't update user.");


            return Ok(new UserDto(user.Id, user.UserName, user.Email));
        }
        [HttpPut]
        [Route("updateemail")]
        public async Task<ActionResult> UpdateEmail(UpdateUserEmailDto updateUserEmailDto)
        {

            var userIdByToken = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userIdByToken == null) return Unauthorized();

            var user = await _userManager.FindByNameAsync(updateUserEmailDto.UserName);

            if (user == null)
                return NotFound("Request invalid because of user name.");

            if (userIdByToken != user.Id) return Unauthorized("The user you trying to edit isn't your profile");




            var token = await _userManager.GenerateChangeEmailTokenAsync(user, updateUserEmailDto.NewEmail);
            if (token == null)
                return BadRequest("User email change isn't possible. Check your new email input field.");

            var result = await _userManager.ChangeEmailAsync(user, updateUserEmailDto.NewEmail, token);

            if (!result.Succeeded)
                return BadRequest("Can't update user email.");


            return Ok(new UserDto(user.Id, user.UserName, user.Email));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
                return BadRequest("User name is invalid.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
                return BadRequest("Password is invalid.");

            //valid user
            var roles = await _userManager.GetRolesAsync(user);
            var accesToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

            return Ok(new SuccessfullLoginDto(accesToken));



        }

        public async Task<ActionResult> Logout()//string userName)
        {

            //var user = _userManager.GetUserAsync(userName);
            //var city = await _userManager.GetAuthenticationTokenAsync(cityid);
            //// 404
            //if (city == null)
            //    return NotFound();
            //await _citiesRepository.DeleteAsync(city);



            //// 204
            //return NoContent();
            var user = await _userManager.FindByNameAsync("paulius33");//logoutDto.UserName);
            if (user == null)
                return BadRequest("Request invalid.");
            var soo = await _userManager.RemoveAuthenticationTokenAsync(user, "HS256", "Bearer");
            _userManager.ResetAuthenticatorKeyAsync(user);
            ////valid user
            //var roles = await _userManager.GetRolesAsync(user);
            //_jwtTokenService.DeleteAccessToken(user.UserName, user.Id, roles);

            return Ok("Deleted?");

        }

    }
}
