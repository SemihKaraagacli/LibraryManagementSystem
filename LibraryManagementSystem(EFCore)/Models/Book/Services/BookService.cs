using AutoMapper;
using FluentValidation;
using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Book.Repositories;
using LibraryManagementSystem_EFCore_.Models.Book.Validations;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;

namespace LibraryManagementSystem_EFCore_.Models.Book.Services
{
    public class BookService(IBookRepository _bookRepository, IMapper _mapper, IValidator<BooksViewModel> _updateViewModel, IValidator<CreateBookViewModel> _createBookViewModel) : IBookService
    {
        public BooksViewModel Add(CreateBookViewModel entity)
        {
            var validate = _createBookViewModel.Validate(entity);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var newbook = new Books() //ekleme işlemi yapılacak yeni bir Books nesnesi oluştur ve books nesnesinin property değerlerini yeni nesneye ata.
            {
                Title = entity.Title,
                Author = entity.Author,
                PublicationYear = entity.PublicationYear,
                ISBN = entity.ISBN,
                Genre = entity.Genre,
                Publisher = entity.Publisher,
                PageCount = entity.PageCount,
                Language = entity.Language,
                Summary = entity.Summary,
                AvailableCopies = entity.AvailableCopies,
            };
            var value = _bookRepository.Add(newbook);
            return _mapper.Map<BooksViewModel>(value);

        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public IQueryable<BooksViewModel> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish)
        {
            var value = _bookRepository.Search(search, title, author, publicationYear, isbn, genre, publish);

            var mappedResult = value.Select(book => _mapper.Map<BooksViewModel>(book));

            return mappedResult;
        }

        public BooksViewModel? GetById(int id)
        {
            var value = _bookRepository.GetById(id);
            return _mapper.Map<BooksViewModel>(value);
        }

        public void Update(BooksViewModel entity)
        {
            var validate = _updateViewModel.Validate(entity);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }

            // Mevcut kitap nesnesini veritabanından bul
            var bookToUpdate = _bookRepository.GetById(entity.Id);

            if (bookToUpdate != null)
            {
                // Bulunan nesnenin özelliklerini güncelle
                bookToUpdate.Title = entity.Title;
                bookToUpdate.Author = entity.Author;
                bookToUpdate.PublicationYear = entity.PublicationYear;
                bookToUpdate.ISBN = entity.ISBN;
                bookToUpdate.Genre = entity.Genre;
                bookToUpdate.Publisher = entity.Publisher;
                bookToUpdate.PageCount = entity.PageCount;
                bookToUpdate.Language = entity.Language;
                bookToUpdate.Summary = entity.Summary;
                bookToUpdate.AvailableCopies = entity.AvailableCopies;

                // Güncellenmiş nesneyi kaydet
                _bookRepository.Update(bookToUpdate);
            }
        }

        public IEnumerable<BooksViewModel> GetAll()
        {
            var value = _bookRepository.GetAll();
            return _mapper.Map<List<BooksViewModel>>(value)!;
        }
    }
}
