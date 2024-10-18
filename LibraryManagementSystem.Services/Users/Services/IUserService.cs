using LibraryManagementSystem.Services.Auth.ViewModel;
using LibraryManagementSystem.Services.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.Users.Services
{
    public interface IUserService
    {
        Task<ServiceResult<UserViewModel>> UserDetail(string id);
        Task<ServiceResult> EditProfile(UserViewModel model, string Id);
        Task<ServiceResult> ChangePassword(ResetPasswordViewModel model, string id);
    }
}
