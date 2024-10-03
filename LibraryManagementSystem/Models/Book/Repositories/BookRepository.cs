namespace LibraryManagementSystem.Models.Book.Responsities
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Books> bookList = new();

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
        }
        public List<Books> GetAllBook()
        {
            return bookList;
        }

        public Books GetById(int id)
        {
            return bookList.FirstOrDefault(x => x.Id == id)!;
        }

        public Books Add(Books books)
        {
            bookList.Add(books);
            return books;
        }

        public void Update(Books books)
        {
            var UpdateBook = bookList.FirstOrDefault(p => p.Id == books.Id);
            if (UpdateBook != null)
            {
                UpdateBook.Title = books.Title;
                UpdateBook.Author = books.Author;
                UpdateBook.PublicationYear = books.PublicationYear;
                UpdateBook.ISBN = books.ISBN;
                UpdateBook.Genre = books.Genre;
                UpdateBook.Publisher = books.Publisher;
                UpdateBook.PageCount = books.PageCount;
                UpdateBook.Language = books.Language;
                UpdateBook.Summary = books.Summary;
                UpdateBook.AvailableCopies = books.AvailableCopies;
                UpdateBook.ImagePath = books.ImagePath; 
                UpdateBook.Image = books.Image;
            }
        }
        public void Delete(int id)
        {
            var bookDelete = bookList.FirstOrDefault(p => p.Id == id);
            if (bookDelete != null)
            {
                bookList.Remove(bookDelete);
            }
        }
    }
}
