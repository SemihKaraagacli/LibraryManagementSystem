using LibraryManagementSystem.Services.Auth.ViewModel;
using LibraryManagementSystem.Services.Users.Services;
using LibraryManagementSystem.Services.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_EFCore_.Controllers
{
    public class ProfileController(IUserService userService) : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            var result = await userService.UserDetail(id);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
            }
            return View(result.Data);
        }
        public async Task<IActionResult> EditProfile(string id)
        {
            var result = await userService.UserDetail(id);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return RedirectToAction("Index");
            }
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserViewModel model, string id)
        {
            var result = await userService.EditProfile(model, id);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return RedirectToAction("Index", "Home", new { message = "Güncelleme başırılı şekilde gerçekleşti." });
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            var result = await userService.UserDetail(id);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return View(new ResetPasswordViewModel { Email = result.Data.Email });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPasswordViewModel model, string id)
        {
            var result = await userService.ChangePassword(model, id);
            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;
                return View();
            }
            return RedirectToAction("Index", "Home", new { message = "Değişim başırılı şekilde gerçekleşti." });
        }
    }
}
