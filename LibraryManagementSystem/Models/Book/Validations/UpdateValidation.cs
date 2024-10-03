using FluentValidation;
using LibraryManagementSystem.Models.Book.ViewModel;

namespace LibraryManagementSystem.Models.Book.Validations
{
    public class UpdateValidation : AbstractValidator<UpdateBookViewModel>
    {
        public UpdateValidation()
        {
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author alanı boş bırakılamaz");
            RuleFor(x => x.PublicationYear).NotEmpty().WithMessage("PublicationYear alanı boş bırakılamaz");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN alanı boş bırakılamaz");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre alanı boş bırakılamaz");
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("Publisher alanı boş bırakılamaz");
            RuleFor(x => x.PageCount).NotEmpty().WithMessage("PageCount alanı boş bırakılamaz");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Language alanı boş bırakılamaz");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("Summary alanı boş bırakılamaz");
            RuleFor(x => x.AvailableCopies).NotEmpty().WithMessage("AvailableCopies alanı boş bırakılamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("ImagePath alanı boş bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title alanı boş bırakılamaz");
        }
    }
}
