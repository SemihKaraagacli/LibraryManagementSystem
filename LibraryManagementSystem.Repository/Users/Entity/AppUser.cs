using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Repository.Users.Entity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FavoriteBookGenre { get; set; }
    }
}
