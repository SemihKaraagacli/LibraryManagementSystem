using LibraryManagementSystem.Services.Auth.ViewModel;

namespace LibraryManagementSystem.Services.Auth.Services
{
    public interface IAuthService
    {
        Task<ServiceResult> SignUp(SignUpViewModel signUpViewModel);
        Task<ServiceResult> SignIn(SignInViewModel signInViewModel);
        Task<ServiceResult> SignOut();
        Task<ServiceResult> VerifyEmail(VerifyEmailViewModel model);
        Task<ServiceResult> ChancePassword(ResetPasswordViewModel model);
        Task<ServiceResult> AddRoleToUser(string roleName, string userId);
        Task<ServiceResult> CreateDefaultRole();
    }
}