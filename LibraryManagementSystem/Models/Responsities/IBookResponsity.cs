namespace LibraryManagementSystem.Models.Responsities
{
    public interface IBookResponsity
    /*
     * dependency inversion prensibinde yüksek seviye nesne düşük seviye nesneye direkt erişim sağlamaması için arada asıl nesneleri temsil etmesi için soyut nesneler üretilmelidir. burada bookrepositoriyi temsil eden soyut sınıf oluşturuldu.
     */
    {
        List<Books> GetAllBook(); //bookrepository içerisindeki getallbook metodunu temsil ediyor.
    }
}
