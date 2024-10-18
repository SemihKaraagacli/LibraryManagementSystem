using AutoMapper;
using LibraryManagementSystem.Repository.Users.Entity;
using LibraryManagementSystem.Services.Auth.ViewModel;
using LibraryManagementSystem.Services.Users.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Services.Users.Services
{
    public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : IUserService
    {
        public async Task<ServiceResult<UserViewModel>> UserDetail(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return ServiceResult<UserViewModel>.Fail("User not found.");
            }
            var model = new UserViewModel
            {
                Email = user.Email,
                FavoriteBookGenre = user.FavoriteBookGenre,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
            return ServiceResult<UserViewModel>.Success(model);
        }

        public async Task<ServiceResult> EditProfile(UserViewModel model, string id)
        {
            var result = await userManager.FindByIdAsync(id);
            if (result == null)
            {
                return ServiceResult.Fail("User not found.");
            }
            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            result.Email = model.Email;
            result.FavoriteBookGenre = model.FavoriteBookGenre;
            await userManager.UpdateAsync(result);
            await Task.Delay(2000);
            await signInManager.SignOutAsync();
            return ServiceResult.Success();


        }
        public async Task<ServiceResult> ChangePassword(ResetPasswordViewModel model, string id)
        {
            var result = await userManager.FindByIdAsync(id);
            if (result == null)
            {
                return ServiceResult.Fail("User not found.");
            }
            var removePassword = await userManager.RemovePasswordAsync(result);
            if (removePassword.Succeeded)
            {
                await userManager.AddPasswordAsync(result, model.NewPassword);
                await Task.Delay(2000);
                await signInManager.SignOutAsync();
                return ServiceResult.Success();
            }
            else
            {
                return ServiceResult.Fail("User not found.");
            }

        }
    }
}
