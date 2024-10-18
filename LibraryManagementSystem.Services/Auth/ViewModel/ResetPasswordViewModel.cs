using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Services.Auth.ViewModel
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;
        [DataType(DataType.Password)]
        public string CofirmNewPassword { get; set; }
    }
}
