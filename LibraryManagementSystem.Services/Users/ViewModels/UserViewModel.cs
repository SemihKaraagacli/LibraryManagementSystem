using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Services.Users.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; } = default!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        public string FavoriteBookGenre { get; set; }
    }
}
