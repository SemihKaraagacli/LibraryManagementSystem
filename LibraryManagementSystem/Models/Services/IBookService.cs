using LibraryManagementSystem.Models.Responsities;

namespace LibraryManagementSystem.Models.Services
{
    public interface IBookService

    /*
     * dependency inversion prensibinde yüksek seviye nesne düşük seviye nesneye direkt erişim sağlamaması için arada asıl nesneleri temsil etmesi için soyut nesneler üretilmelidir. burada bookservisi temsil eden soyut sınıf oluşturuldu.
     */
    {
        List<Books> GetAllBook(); //bookservice'de ki metodu temsil etmektedir. Listeleme yapılacağı için liste halinde verilmiştir.

        Books GetByIdBook(int id);//bookservice'de ki metodu temsil etmektedir. istenilen ıd deki veriler getirileceği için books nesnesinden türetilmişmiştir.
    }
}
