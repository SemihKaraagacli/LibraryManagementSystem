namespace LibraryManagementSystem.Services.Book.ViewModel
{
    public record BooksViewModel(int Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies);
}
