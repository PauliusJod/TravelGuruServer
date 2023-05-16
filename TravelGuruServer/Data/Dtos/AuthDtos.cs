using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Data.Dtos
{
    public class AuthDtos
    {
        public record RegisterUserDto([Required] string UserName, [EmailAddress][Required] string Email, [Required] string Password);
        public record LoginDto(string UserName, string Password);
        public record UpdateUserPasswordDto(string UserName, string CurrentPassword, string NewPassword);
        public record UpdateUserEmailDto(string UserName,[EmailAddress] string NewEmail);


        public record UserDto(string Id, string UserName, string Email);


        public record SuccessfullLoginDto(string AccessToken);
    }
}