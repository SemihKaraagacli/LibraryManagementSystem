using LibraryManagementSystem.Repository.Migrations;
using LibraryManagementSystem.Repository.Users.Entity;
using LibraryManagementSystem.Services.Auth.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LibraryManagementSystem.Services.Auth.Services
{
    public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : IAuthService
    {
        public async Task<ServiceResult> SignUp(SignUpViewModel signUpViewModel)
        {

            var appUser = new AppUser
            {
                UserName = signUpViewModel.UserName,
                FirstName = signUpViewModel.FirstName,
                LastName = signUpViewModel.LastName,
                Email = signUpViewModel.Email,
                FavoriteBookGenre = signUpViewModel.FavoriteBookGenre,
            };

            var result = await userManager.CreateAsync(appUser, signUpViewModel.Password);

            if (!result.Succeeded)
            {
                var errorsToList = result.Errors.Select(x => x.Description).ToList();
                return ServiceResult.Fail(errorsToList);
            }
            await userManager.AddClaimAsync(appUser, new Claim("FirstName", appUser.FirstName));
            await userManager.AddClaimAsync(appUser, new Claim("LastName", appUser.LastName));

            return ServiceResult.Success();
        }
        public async Task<ServiceResult> SignIn(SignInViewModel signInViewModel)
        {
            var user = await userManager.FindByEmailAsync(signInViewModel.Email);
            if (user == null)
            {
                return ServiceResult.Fail(new List<string> { "Email or password is wrong." });
            }
            var result = await userManager.CheckPasswordAsync(user, signInViewModel.Password);
            if (!result)
            {
                return ServiceResult.Fail(new List<string> { "Email or password is wrong." });
            }
            await signInManager.SignInAsync(user, true);
            return ServiceResult.Success();
        }
        public async Task<ServiceResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return ServiceResult.Success();
        }
        public async Task<ServiceResult> VerifyEmail(VerifyEmailViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return ServiceResult.Fail(new List<string> { "User not found." });
            }
            return ServiceResult.Success();
        }
        public async Task<ServiceResult> ChancePassword(ResetPasswordViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return ServiceResult.Fail("User not found.");
            }
            var result = await userManager.RemovePasswordAsync(user);

            if (result.Succeeded)
            {
                result = await userManager.AddPasswordAsync(user, model.NewPassword);
                return ServiceResult.Success();
            }
            else
            {
                return ServiceResult.Fail("User not found.");
            }
        }
        public async Task<ServiceResult> CreateDefaultRole()
        {
            var adminRoleName = "Admin";
            var userRoleName = "User";
            var adminRole = await roleManager.FindByNameAsync(adminRoleName);

            if (adminRole is null)
            {
                var result = await roleManager.CreateAsync(new AppRole
                {
                    Name = adminRoleName,
                });
                if (!result.Succeeded)
                {
                    var error = result.Errors.Select(x => x.Description).ToList();
                    return ServiceResult.Fail(error.First());
                }
                return ServiceResult.Success();
            }
            var userRole = await roleManager.FindByNameAsync(userRoleName);
            if (userRole is null)
            {
                var result = await roleManager.CreateAsync(new AppRole
                {
                    Name = userRoleName,
                });
                if (!result.Succeeded)
                {
                    var error = result.Errors.Select(x => x.Description).ToList();
                    return ServiceResult.Fail(error.First());
                }
                return ServiceResult.Success();
            }

            return ServiceResult.Success();

        }
        public async Task<ServiceResult> AddRoleToUser(string roleName, string userId)
        {
            var hasUser = await userManager.FindByIdAsync(userId);

            if (hasUser is null)
            {
                return ServiceResult.Fail("User not found.");
            }

            var hasRole = await roleManager.FindByNameAsync(roleName);

            if (hasRole == null)
            {
                return ServiceResult.Fail("Role not found.");
            }

            var result = await userManager.AddToRoleAsync(hasUser, roleName);

            if (!result.Succeeded)
            {
                var error = result.Errors.Select(x => x.Description).ToList();
                return ServiceResult.Fail(error.First());
            }
            return ServiceResult.Success();
        }
    }
}
