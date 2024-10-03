namespace LibraryManagementSystem.Models.Book.ViewModel
{
    public record UpdateBookViewModel(int Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies, string ImagePath, IFormFile Image);
}
