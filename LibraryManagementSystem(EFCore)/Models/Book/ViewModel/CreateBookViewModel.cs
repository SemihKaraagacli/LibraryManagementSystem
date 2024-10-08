﻿namespace LibraryManagementSystem_EFCore_.Models.Book.ViewModel
{
    public record CreateBookViewModel(string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies);
}