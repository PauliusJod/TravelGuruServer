using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Auth;
using static TravelGuruServer.Data.Dtos.AuthDtos;

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
                return BadRequest("Request invalid.");

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
