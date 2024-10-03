using AutoMapper;
using LibraryManagementSystem.Models.Book.Responsities;
using LibraryManagementSystem.Models.Book.ViewModel;

namespace LibraryManagementSystem.Models.Mappins
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Books, BookViewModel>().ReverseMap(); //Books sınıfı ile BookViewModel sınıfı arasında karşılıklı bir haritalama oluşturur.
            CreateMap<Books, UpdateBookViewModel>().ReverseMap();//Books sınıfı ile UpdateBookViewModel sınıfı arasında karşılıklı bir haritalama oluşturur.
            CreateMap<Books, CreateBookViewModel>().ReverseMap();//Books sınıfı ile CreateBookViewModel sınıfı arasında karşılıklı bir haritalama oluşturur.
            CreateMap<BookViewModel, UpdateBookViewModel>().ReverseMap();//BookViewModel sınıfı ile UpdateBookViewModel sınıfı arasında karşılıklı bir haritalama oluşturur.
        }
    }
}
