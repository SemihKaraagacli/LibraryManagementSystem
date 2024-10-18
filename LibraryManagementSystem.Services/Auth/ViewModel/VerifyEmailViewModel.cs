using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Services.Auth.ViewModel
{
    public class VerifyEmailViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
