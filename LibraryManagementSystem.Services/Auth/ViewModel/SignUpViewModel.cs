using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Services.Auth.ViewModel
{
    public class SignUpViewModel
    {
        public string UserName { get; set; } = default!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        public string FavoriteBookGenre { get; set; }
        public string FullName { get; set; } = default!;
    }
}
