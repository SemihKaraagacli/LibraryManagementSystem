using AutoMapper;
using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;

namespace LibraryManagementSystem_EFCore_.Models.Mappers
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<Books, BooksViewModel>().ReverseMap();
            CreateMap<Books, CreateBookViewModel>().ReverseMap();
            CreateMap<BooksViewModel, CreateBookViewModel>().ReverseMap();
        }
    }
}
