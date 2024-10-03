using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using LibraryManagementSystem.Models.Book.Responsities;
using LibraryManagementSystem.Models.Book.ViewModel;

namespace LibraryManagementSystem.Models.Book.Services
{
    public class BookService(
        IBookRepository booksRepository,
        IMapper _mapper,
        IValidator<CreateBookViewModel> _createValidator,
        IValidator<UpdateBookViewModel> _updateValidator
        ) : IBookService
    {
        public List<BookViewModel> GetAll()
        {
            var book = booksRepository.GetAllBook();
            return _mapper.Map<List<BookViewModel>>(book)!; //AutoMapper ile book nesnesini bookviewmodel nesnesine uygun haritalandırma işlemi yapıldı.
            //book.Select(item => new BookViewModel(item.Id, item.Title, item.Author, item.PublicationYear, item.ISBN, item.Genre, item.Publisher, item.PageCount, item.Language, item.Summary, item.AvailableCopies, item.ImagePath)).ToList();
        }

        public BookViewModel? GetById(int id)
        {
            var book = booksRepository.GetById(id);
            if (book == null)
            {
                return null;
            }
            return _mapper?.Map<BookViewModel>(book)!;//AutoMapper ile book nesnesini bookviewmodel nesnesine uygun haritalandırma işlemi yapıldı.
            //

        }

        public BookViewModel Add(CreateBookViewModel books)
        {
            var vR = _createValidator.Validate(books); //books nesnesi için bir doğrulama işlemi gerçekleştir ve sonucu vR değişkenine ata.
            if (!vR.IsValid) //Eğer doğrulama sonucu geçerli değilse (yani IsValid false ise), devam et.
            {
                throw new ValidationException(vR.Errors); //Geçersiz doğrulama durumunda, doğrulama hatalarını içeren bir ValidationException fırlat.
            }

            var booksCount = GetAll().Count; //GetAll() metodu çağrılarak veritabanındaki veya koleksiyondaki tüm kitapların sayısı alınıyor ve booksCount değişkenine atanıyor.

            var newbook = new Books() //ekleme işlemi yapılacak yeni bir Books nesnesi oluştur ve books nesnesinin property değerlerini yeni nesneye ata.
            {
                Id = booksCount + 1,
                Title = books.Title,
                Author = books.Author,
                PublicationYear = books.PublicationYear,
                ISBN = books.ISBN,
                Genre = books.Genre,
                Publisher = books.Publisher,
                PageCount = books.PageCount,
                Language = books.Language,
                Summary = books.Summary,
                AvailableCopies = books.AvailableCopies,
                Image = books.Image,
            };
            if (books.Image != null)
            {
                var fileName = Path.GetFileName(books.Image.FileName);//books.Image nesnesinin dosya adını al ve fileName değişkenine ata
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName); //Dosyanın tam yolunu oluştur; mevcut çalışma dizini ile "wwwroot/image" klasörünü ve dosya adını birleştir.


                using (var stream = new FileStream(filePath, FileMode.Create))//Belirtilen dosya yolunda yeni bir dosya oluşturmak için bir dosya akışı (FileStream) aç.
                {
                    books.Image.CopyTo(stream); // Resmi dosya sistemine kopyala
                }

                newbook.ImagePath = "/image/" + fileName; // bookToUpdate nesnesinin ImagePath özelliğini, kaydedilen resmin yolu ile güncelle
            }
            booksRepository.Add(newbook); //Oluşturulan newbook nesnesi, booksRepository aracılığıyla veritabanına ekleniyor.
            return _mapper.Map<BookViewModel>(newbook)!;//AutoMapper ile newbook nesnesini bookviewmodel nesnesine uygun haritalandırma işlemi yapıldı.

            //new BookViewModel(newbook.Id, newbook.Title, newbook.Author, newbook.PublicationYear, newbook.ISBN, newbook.Genre, newbook.Publisher, newbook.PageCount, newbook.Language, newbook.Summary, newbook.AvailableCopies, newbook.ImagePath);
        }

        public void Update(UpdateBookViewModel books)
        {
            var vR = _updateValidator.Validate(books); //books nesnesi için bir doğrulama işlemi gerçekleştir ve sonucu vR değişkenine ata.
            if (!vR.IsValid) //Eğer doğrulama sonucu geçerli değilse (yani IsValid false ise), devam et.
            {
                throw new ValidationException(vR.Errors); //Geçersiz doğrulama durumunda, doğrulama hatalarını içeren bir ValidationException fırlat.
            }

            var bookToUpdate = new Books() //Güncellenecek yeni bir Books nesnesi oluştur ve books nesnesinin property değerlerini yeni nesneye ata.
            {
                Id = books.Id,
                Title = books.Title,
                Author = books.Author,
                PublicationYear = books.PublicationYear,
                ISBN = books.ISBN,
                Genre = books.Genre,
                Publisher = books.Publisher,
                PageCount = books.PageCount,
                Language = books.Language,
                Summary = books.Summary,
                AvailableCopies = books.AvailableCopies,
                Image = books.Image,
                ImagePath = books.ImagePath,
            };

            if (books.Image != null)
            {
                var fileName = Path.GetFileName(books.Image.FileName); //books.Image nesnesinin dosya adını al ve fileName değişkenine ata
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName); //Dosyanın tam yolunu oluştur; mevcut çalışma dizini ile "wwwroot/image" klasörünü ve dosya adını birleştir.

                using (var stream = new FileStream(filePath, FileMode.Create)) //Belirtilen dosya yolunda yeni bir dosya oluşturmak için bir dosya akışı (FileStream) aç.
                {
                    books.Image.CopyTo(stream); // Resmi dosya sistemine kopyala
                }

                bookToUpdate.ImagePath = "/image/" + fileName; // bookToUpdate nesnesinin ImagePath özelliğini, kaydedilen resmin yolu ile güncelle
            }
            booksRepository.Update(bookToUpdate!); //güncellenen bookToUpdate nesnesi, booksRepository aracılığıyla veritabanına ekleniyor.
        }
        public void Delete(int id)
        {
            booksRepository.Delete(id);
        }
    }
}
