namespace LibraryManagementSystem.Models.Responsities
{
    public class BookRepository:IBookResponsity // İnterface'i miras aldı.
    {
        private static List<Books> bookList = new();
        /*
         private Books entity sınıfından üretilen ve türetilen bir bookList bulunmakta bu nesneyi kullanan her sınıf için ayrı ayrı üretilmeyip her kullanan sınıf için tek bir tane liste olması için static hale getirildi. Altında static constructor içerisinde listeye eklenecek olan veriler verilmiştir.
         */
        static BookRepository()
        {
            bookList.Add(new Books
            {
                Id = 1,
                Title = "Gizemli Bahçe",
                Author = "Frances Hodgson Burnett",
                PublicationYear = 1911,
                ISBN = "978-1234567890",
                Genre = "Roman",
                Publisher = "İletişim Yayınları",
                PageCount = 320,
                Language = "Türkçe",
                Summary = "Küçük bir kızın gizemli bir bahçeyi keşfetmesini konu alıyor.",
                AvailableCopies = 3,
                ImagePath = "/image/GizemliBahçe.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 2,
                Title = "Zamanın Kıyameti",
                Author = "H.G. Wells",
                PublicationYear = 1895,
                ISBN = "978-2345678901",
                Genre = "Bilim Kurgu",
                Publisher = "Alfa Yayınları",
                PageCount = 250,
                Language = "Türkçe",
                Summary = "Zaman yolculuğu yapan bir adamın hikayesini anlatıyor.",
                AvailableCopies = 5,
                ImagePath = "/image/ZamanınKiyameti.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 3,
                Title = "Yüz Yıllık Yalnızlık",
                Author = "Gabriel García Márquez",
                PublicationYear = 1967,
                ISBN = "978-3456789012",
                Genre = "Roman",
                Publisher = "Can Yayınları",
                PageCount = 450,
                Language = "Türkçe",
                Summary = "Bu eser, Buendía ailesinin büyüleyici hikayesini sunar.",
                AvailableCopies = 2,
                ImagePath = "/image/Yüz_Yıllık_Yalnızlık.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 4,
                Title = "Savaş ve Barış",
                Author = "Lev Tolstoy",
                PublicationYear = 1869,
                ISBN = "978-4567890123",
                Genre = "Tarih",
                Publisher = "Yapı Kredi Yayınları",
                PageCount = 1200,
                Language = "Türkçe",
                Summary = "Napoleon döneminde Rusya'nın sosyal yapısını inceleyen bir eser.",
                AvailableCopies = 1,
                ImagePath = "/image/SavaşveBarış.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 5,
                Title = "Yıldızlararası",
                Author = "Arthur C. Clarke",
                PublicationYear = 1968,
                ISBN = "978-5678901234",
                Genre = "Bilim Kurgu",
                Publisher = "Pegasus Yayınları",
                PageCount = 350,
                Language = "Türkçe",
                Summary = "Uzayda yaşamı araştıran bir grup bilim insanının serüveni.",
                AvailableCopies = 4,
                ImagePath = "/image/yıldızlararası.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 6,
                Title = "Aşk ve Zaman",
                Author = "Elif Şafak",
                PublicationYear = 2010,
                ISBN = "978-6789012345",
                Genre = "Roman",
                Publisher = "Doğan Kitap",
                PageCount = 400,
                Language = "Türkçe",
                Summary = "Aşkın farklı zaman dilimlerinde nasıl değiştiğini anlatıyor.",
                AvailableCopies = 6,
                ImagePath = "/image/AşkveZaman.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 7,
                Title = "Gölgesizler",
                Author = "Hasan Ali Toptaş",
                PublicationYear = 1995,
                ISBN = "978-7890123456",
                Genre = "Roman",
                Publisher = "Epsilon Yayınları",
                PageCount = 210,
                Language = "Türkçe",
                Summary = "Bir köyde geçen gizemli olayları konu alıyor.",
                AvailableCopies = 5,
                ImagePath = "/image/Gölgesizler.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 8,
                Title = "Küçük Prens",
                Author = "Antoine de Saint-Exupéry",
                PublicationYear = 1943,
                ISBN = "978-8901234567",
                Genre = "Çocuk",
                Publisher = "Remzi Kitabevi",
                PageCount = 100,
                Language = "Türkçe",
                Summary = "Bir çocuğun hayal gücünü keşfetme yolculuğu.",
                AvailableCopies = 10,
                ImagePath = "/image/KüçükPrens.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 9,
                Title = "Simyacı",
                Author = "Paulo Coelho",
                PublicationYear = 1988,
                ISBN = "978-9012345678",
                Genre = "Roman",
                Publisher = "Martı Yayınları",
                PageCount = 208,
                Language = "Türkçe",
                Summary = "Kendi hayallerinin peşinden koşan bir çobanın hikayesi.",
                AvailableCopies = 7,
                ImagePath = "/image/Simyacı.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 10,
                Title = "Kayıp Zamanın İzinde",
                Author = "Marcel Proust",
                PublicationYear = 1913,
                ISBN = "978-0123456789",
                Genre = "Roman",
                Publisher = "Buzdağı Yayınları",
                PageCount = 600,
                Language = "Türkçe",
                Summary = "Zaman ve bellek üzerine derin düşünceler içeren bir eser.",
                AvailableCopies = 1,
                ImagePath = "/image/KayıpZamanınİzinde.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 11,
                Title = "Yalnızız",
                Author = "Adalet Ağaoğlu",
                PublicationYear = 1973,
                ISBN = "978-1234567891",
                Genre = "Roman",
                Publisher = "İletişim Yayınları",
                PageCount = 290,
                Language = "Türkçe",
                Summary = "Modern Türkiye'de insan ilişkilerinin karmaşasını anlatıyor.",
                AvailableCopies = 4,
                ImagePath = "/image/Yalnızız.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 12,
                Title = "Korkunun Kralı",
                Author = "Stephen King",
                PublicationYear = 1986,
                ISBN = "978-2345678902",
                Genre = "Korku",
                Publisher = "Altın Kitaplar",
                PageCount = 450,
                Language = "Türkçe",
                Summary = "Korkunun insan psikolojisi üzerindeki etkilerini inceliyor.",
                AvailableCopies = 2,
                ImagePath = "/image/KorkununKralı.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 13,
                Title = "Yüreğim Var",
                Author = "Buket Uzuner",
                PublicationYear = 2015,
                ISBN = "978-3456789013",
                Genre = "Roman",
                Publisher = "Everest Yayınları",
                PageCount = 330,
                Language = "Türkçe",
                Summary = "Aşkın ve hayal gücünün sınırlarını zorlayan bir hikaye.",
                AvailableCopies = 3,
                ImagePath = "/image/YüreğimVar.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 14,
                Title = "İstanbul Hatırası",
                Author = "Ahmet Ümit",
                PublicationYear = 2013,
                ISBN = "978-4567890124",
                Genre = "Polisiye",
                Publisher = "Everest Yayınları",
                PageCount = 400,
                Language = "Türkçe",
                Summary = "İstanbul'da geçen bir cinayet soruşturmasını ele alıyor.",
                AvailableCopies = 5,
                ImagePath = "/image/İstanbulHatırası.jpeg"
            });
            bookList.Add(new Books()
            {
                Id = 15,
                Title = "Denizler Altında Yirmi Bin Fersah",
                Author = "Jules Verne",
                PublicationYear = 1870,
                ISBN = "978-5678901235",
                Genre = "Macera",
                Publisher = "İş Bankası Kültür Yayınları",
                PageCount = 350,
                Language = "Türkçe",
                Summary = "Denizaltı yaşamını keşfeden bir grup maceraperestin hikayesi.",
                AvailableCopies = 6,
                ImagePath = "/image/DenizlerAltındaYirmiBinFersah.jpeg"
            });
        }
        public List<Books> GetAllBook()   //Books Sınıfından oluşan bir metod oluşturulup içerisinde yukarıda Books listesinden oluşturulan bookList döndürülüyor.
        {
            return bookList;
        }
    }
}
