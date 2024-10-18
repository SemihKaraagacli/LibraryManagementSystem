using AutoMapper;
using FluentValidation;
using LibraryManagementSystem.Repository.Book.Entities;
using LibraryManagementSystem.Repository.Book.Repositories;
using LibraryManagementSystem.Services.Book.ViewModel;

namespace LibraryManagementSystem.Services.Book.Services
{
    public class BookService(IBookRepository _bookRepository, IMapper _mapper, IValidator<BooksViewModel> _updateViewModel, IValidator<CreateBookViewModel> _createBookViewModel) : IBookService
    {
        public ServiceResult<BooksViewModel> Add(CreateBookViewModel entity)
        {
            //VALIDATE PROCESSES
            var validate = _createBookViewModel.Validate(entity);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }

            //SERVICE RESULT ERROR CHECK
            var hasBook = _bookRepository.Any(p => p.ISBN == entity.ISBN);
            if (hasBook)
            {
                return ServiceResult<BooksViewModel>.Fail("Bu isimde ürün zaten mevcut.");
            }

            //ADD PROCESSES
            var newbook = new Books()
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
            var newBookViewModel = _mapper.Map<BooksViewModel>(value);
            return ServiceResult<BooksViewModel>.Success(newBookViewModel);


        }

        public ServiceResult Delete(int id)
        {

            //SERVİCE RESULT ERROR CHECK
            var hasBook = _bookRepository.Any(p => p.Id == id);
            if (!hasBook)
            {
                return ServiceResult.Fail("Silinecek ürün bulunamamıştır.");
            }

            //DELETE PROCESSES
            _bookRepository.Delete(id);
            return ServiceResult.Success();
        }

        public ServiceResult<IQueryable<BooksViewModel>> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publisher)
        {
            var value = _bookRepository.Search(search, title, author, publicationYear, isbn, genre, publisher);

            var mappedResult = value.Select(book => _mapper.Map<BooksViewModel>(book));
            return ServiceResult<IQueryable<BooksViewModel>>.Success(mappedResult);
        }

        public ServiceResult<BooksViewModel> GetById(int id)
        {
            //ID PROCESSES
            var value = _bookRepository.GetById(id);

            //ID NULL CHECK AND SERVİCE RESULT ERROR CHECK
            if (value == null)
            {
                return ServiceResult<BooksViewModel>.Fail("Kitap Bulunamadı.");
            }
            var newBook = _mapper.Map<BooksViewModel>(value);
            return ServiceResult<BooksViewModel>.Success(newBook);


        }

        public ServiceResult Update(BooksViewModel entity)
        {
            //VALIDATE PROCESSES
            var validate = _updateViewModel.Validate(entity);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }

            //SERVİCE RESULT ERROR CHECK
            var hasBook = _bookRepository.Any(p => p.Id == entity.Id);
            if (!hasBook)
            {
                return ServiceResult.Fail("güncellenecek ürün bulunamamıştır.");
            }


            //ID PROCESSES
            var bookToUpdate = _bookRepository.GetById(entity.Id);

            //ID NULL CHECK AND MATCHING DATA IN THE DATABASE TO INCOMING DATA
            if (bookToUpdate != null)
            {
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
            }

            //UPDATE PROCESSES
            _bookRepository.Update(bookToUpdate);
            return ServiceResult.Success();

        }

        public ServiceResult<List<BooksViewModel>> GetAll()
        {
            //RETRIEVING DATA FROM THE DATABASE
            var value = _bookRepository.GetAll();
            var data = _mapper.Map<List<BooksViewModel>>(value)!;
            return ServiceResult<List<BooksViewModel>>.Success(data);
        }
    }
}
