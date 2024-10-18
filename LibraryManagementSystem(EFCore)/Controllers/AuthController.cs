using LibraryManagementSystem.Repository.Users.Entity;
using LibraryManagementSystem.Services.Auth.Services;
using LibraryManagementSystem.Services.Auth.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagementSystem_EFCore_.Controllers
{
    public class AuthController(IAuthService authService, SignInManager<AppUser> signInManager) : Controller
    {
        [Authorize]
        public async Task<IActionResult> AddRoleToUser()
        {

            await authService.CreateDefaultRole();
            var user = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var result = await authService.AddRoleToUser("Admin", user);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            var result = await authService.SignUp(signUpViewModel);

            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> SignIn()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            await authService.CreateDefaultRole();
            var result = await authService.SignIn(signInViewModel);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            var user = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var userResult = await authService.AddRoleToUser("User", user);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            var result = await authService.SignOut();
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            var user = await authService.VerifyEmail(model);
            if (user.AnyError)
            {
                TempData["error"] = user.GetFirstError;
                return View();
            }
            return RedirectToAction("ChangePassword", "Auth", new { Email = model.Email });
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return RedirectToAction("VerifyEmail", "Auth");
            }
            return View(new ResetPasswordViewModel { Email = Email });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPasswordViewModel model)
        {
            var result = await authService.ChancePassword(model);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return RedirectToAction("SignIn", "Auth");
        }

    }
}
