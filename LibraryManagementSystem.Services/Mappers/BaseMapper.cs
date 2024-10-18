using AutoMapper;
using LibraryManagementSystem.Repository.Book.Entities;
using LibraryManagementSystem.Repository.Users.Entity;
using LibraryManagementSystem.Services.Book.ViewModel;
using LibraryManagementSystem.Services.Users.ViewModels;

namespace LibraryManagementSystem.Services.Mappers
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<Books, BooksViewModel>().ReverseMap();
            CreateMap<Books, CreateBookViewModel>().ReverseMap();
            CreateMap<BooksViewModel, CreateBookViewModel>().ReverseMap();
            CreateMap<AppUser, UserViewModel>().ReverseMap();
        }
    }
}
