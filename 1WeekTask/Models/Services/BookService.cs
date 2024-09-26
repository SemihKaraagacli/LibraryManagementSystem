using _1WeekTask.Models.Responsities;

namespace _1WeekTask.Models.Services
{
    public class BookService(IBookResponsity booksResponsity) : IBookService
        /*
         BookService burada bookservice interface'i miras almıştır. ve primary constructor ile Ibookrepository den üretilen bir nesneyi tutmaktadır.
         */
    {
        public List<Books> GetAllBook()
        {
            return booksResponsity.GetAllBook(); //interfaceden gelen metod kullanılarak tüm kitapları getiriyor.
        }

        public Books GetByIdBook(int id) //istenilen ıd deki veriler getirileceği için books nesnesinden türetilmişmiştir. İstenilen ıd reporsitorydeki tüm ıdler ile karşılaştırılıp uyumlu olan çağılılıcaktır.
        {
            return booksResponsity.GetAllBook().FirstOrDefault(x => x.Id == id)!;
        }
    }

}
