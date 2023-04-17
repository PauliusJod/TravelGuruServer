using Microsoft.AspNetCore.Identity;
using TravelGuruServer.Auth.Model;

namespace TravelGuruServer.Data
{
    public class AuthDbSeeder
    {

        public readonly UserManager<TravelUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;


        public AuthDbSeeder(UserManager<TravelUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }
        private async Task AddAdminUser()
        {
            var newAdminUser = new TravelUser()
            {
                UserName = "admin",
                Email = "admin@ad.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "!Admin.2023");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, TravelUserRoles.All);
                }
            }
        }
        private async Task AddDefaultRoles()
        {
            foreach (var role in TravelUserRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
