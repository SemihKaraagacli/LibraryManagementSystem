namespace LibraryManagementSystem.Models.Book.Responsities
{
    public interface IBookRepository
    /*
     * dependency inversion prensibinde yüksek seviye nesne düşük seviye nesneye direkt erişim sağlamaması için arada asıl nesneleri temsil etmesi için soyut nesneler üretilmelidir. burada bookrepositoriyi temsil eden soyut sınıf oluşturuldu.
     */
    {
        List<Books> GetAllBook(); //bookrepository içerisindeki getallbook metodunu temsil ediyor.

        Books GetById(int id);

        Books Add(Books book);

        void Update(Books book);
        void Delete(int id);
    }
}
